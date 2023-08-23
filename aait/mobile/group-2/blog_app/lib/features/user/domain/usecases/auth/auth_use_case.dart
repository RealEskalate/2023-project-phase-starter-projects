import 'package:dartz/dartz.dart';

import '../../../../../core/error/failure.dart';
import '../../entities/auth/login_entity.dart';
import '../../entities/auth/sign_up_entity.dart';

import '../../entities/user_data.dart';
import '../../repositories/auth/auth_repo.dart';

abstract class UseCase<Type, Params> {
  Future<Either<Failure, Type>> call(Params params);
}

class LoginUseCase extends UseCase<UserData, LoginRequestEntity> {
  final AuthRepository authRepository;
  LoginUseCase({required this.authRepository});
  @override
  Future<Either<Failure, UserData>> call(LoginRequestEntity params) async {
    return await authRepository.login(params);
  }
}

class SignUpUseCase extends UseCase<UserData, SignUpEntity> {
  final AuthRepository authRepository;

  SignUpUseCase({required this.authRepository});

  @override
  Future<Either<Failure, UserData>> call(SignUpEntity params) async {
    return await authRepository.signIn(params);
  }
}
