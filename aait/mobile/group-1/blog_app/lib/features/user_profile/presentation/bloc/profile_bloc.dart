import 'package:bloc/bloc.dart';
import 'package:blog_app/core/network/network_info.dart';
import 'package:blog_app/features/user_profile/data/datasources/profile_local_data_source.dart';
import 'package:blog_app/features/user_profile/data/datasources/proile_remote_data_source.dart';
import 'package:blog_app/features/user_profile/data/repository/user_repository_implementaion.dart';
import 'package:blog_app/features/user_profile/domain/repositories/user_repository.dart';
import 'package:blog_app/features/user_profile/domain/usecases/get_user_info.dart';
import 'package:meta/meta.dart';

import '../../../../injection_container.dart';
import '../../domain/entities/user_entity.dart';

part 'profile_event.dart';
part 'profile_state.dart';

class ProfileBloc extends Bloc<ProfileEvent, ProfileState> {
  ProfileBloc() : super(ProfileInitial()) {
    ProfileRemoteDataSource remoteDataSource = sl();
    ProfileLocalDataSource localDataSource = sl();
    NetworkInfo networkInfo = sl();
    UserRepository repository = UserRepositoryImpl(
        localDataSource: localDataSource,
        remoteDataSource: remoteDataSource,
        networkInfo: networkInfo);
    GetUserInfo usecase = GetUserInfo(repository);

    on<ProfileEvent>((event, emit) async {
      if (event is GetProfileInfo) {
        emit(Loading());
        final userInfo = await usecase();
        if (userInfo.isRight()) {
          userInfo.fold(
              (failure) => emit(Error()), (userInfo) => emit(Loaded(userInfo)));
        }
      }
    });
  }
}
