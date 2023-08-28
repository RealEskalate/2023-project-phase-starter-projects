import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/login_user_entitiy.dart';
import '../entities/user_data_entity.dart';
import '../repositories/auth_repository.dart';
import 'user_use_case.dart';


class LoginUseCase implements UseCase<UserDataEntity, LoginUserEnity> {
  final AuthRepository repository;
  LoginUseCase({required this.repository});

  @override
  Future<Either<Failure, UserDataEntity>> call(
      LoginUserEnity loginUserEnity) async {
    return await repository.login(loginUserEnity);
  }
}