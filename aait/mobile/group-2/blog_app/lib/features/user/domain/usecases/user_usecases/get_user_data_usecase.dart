import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../../core/error/failure.dart';
import '../../../../../core/usecase/usecase.dart';
import '../../entities/user_data.dart';
import '../../repositories/user_repository.dart';

class GetUserData implements UseCase<UserData, GetUserDataParams> {
  final UserRepository userRepository;

  GetUserData(this.userRepository);

  @override
  Future<Either<Failure, UserData>> call(GetUserDataParams params) async {
    return await userRepository.getUserData(params.userId);
  }
}

class GetUserDataParams extends Equatable {
  final String userId;

  const GetUserDataParams({required this.userId});

  @override
  List<Object?> get props => [userId];
}