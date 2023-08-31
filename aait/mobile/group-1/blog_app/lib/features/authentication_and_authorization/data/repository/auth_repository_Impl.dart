import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/exception.dart';
import '../../../../core/errors/failures/failure.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/login_user_entitiy.dart';
import '../../domain/entities/sign_up_user_entity.dart';
import '../../domain/entities/user_data_entity.dart';
import '../../domain/repositories/auth_repository.dart';
import '../data_source/auth_local_data_source.dart';
import '../data_source/auth_remote_data_source.dart';
import '../models/login_user_model.dart';
import '../models/sign_up_user_model.dart';
import '../models/user_data_model.dart';

class AuthRepositoryImpl extends AuthRepository {
  final AuthRemoteDataSource authRemoteDataSource;
  final AuthLocalDataSource authLocalDataSource;
  final NetworkInfo networkInfo;
  AuthRepositoryImpl(
      {required this.authLocalDataSource,
      required this.authRemoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, SignUpUserEnity>> signup(
      SignUpUserEnity signUpUserEnity) async {
    if (await networkInfo.isConnected) {
      try {
        SignUpModel newUserModel = SignUpModel(
          fullName: signUpUserEnity.fullName,
          email: signUpUserEnity.email,
          password: signUpUserEnity.password,
          expertise: signUpUserEnity.expertise,
          bio: signUpUserEnity.bio,
        );

        final remoteSignup = await authRemoteDataSource.signup(newUserModel);

        return Right(remoteSignup);
      } on ServerException catch (e) {
        return Left(ServerFailure(message: "Server Error"));
      }
    } else {
      return Left(ConnectionFailure(message: "No Internet Connection"));
    }
  }

  @override
  Future<Either<Failure, UserDataEntity>> login(
      LoginUserEnity loginUserEnity) async {
    if (await networkInfo.isConnected) {
      try {
        LoginUserModel loginUserModel = LoginUserModel(
            email: loginUserEnity.email, password: loginUserEnity.password);
        final remotelogin = await authRemoteDataSource.login(loginUserModel);
        authLocalDataSource.cacheToken(remotelogin.token);
        // print("shared token");
        // print(await authLocalDataSource.getToken());
        // print("shared user");
        // print(await authLocalDataSource.getUser());

        authLocalDataSource.setUser(DataModel(
            id: remotelogin.data.id,
            fullName: remotelogin.data.fullName,
            email: remotelogin.data.email,
            password: remotelogin.data.password,
            expertise: remotelogin.data.expertise,
            bio: remotelogin.data.bio,
            createdAt: remotelogin.data.createdAt,
            image: remotelogin.data.image,
            imageCloudinaryPublicId: remotelogin.data.imageCloudinaryPublicId,
            articles: []));

        return Right(remotelogin);
      } on ServerException catch (e) {
        return Left(ServerFailure(message: "Server Error"));
      }
    } else {
      return Left(ConnectionFailure(message: "No Internet Connection"));
    }
  }
}
