import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/authenticated_user_info.dart';
import '../entities/authentication_entity.dart';
import '../entities/login_entity.dart';
import '../entities/sign_up_entity.dart';
import '../repositories/auth_repo.dart';

abstract class UseCase<Type, Params> {
  Future<Either<Failure, Type>> call(Params params);
}

class LoginUseCase extends UseCase<AuthenticationEntity, LoginRequestEntity> {
  final AuthRepository authRepository;
  LoginUseCase({required this.authRepository});
  @override
  Future<Either<Failure, AuthenticationEntity>> call(
      LoginRequestEntity params) async {
    return await authRepository.login(params);
  }
}

class SignUpUseCase extends UseCase<AuthenticatedUserInfo, SignUpEntity> {
  final AuthRepository authRepository;

  SignUpUseCase({required this.authRepository});

  @override
  Future<Either<Failure, AuthenticatedUserInfo>> call(
      SignUpEntity params) async {
    return await authRepository.signUp(params);
  }
}

class LogoutUseCase extends UseCase<void, String> {
  final AuthRepository authRepository;
  LogoutUseCase({required this.authRepository});
  @override
  Future<Either<Failure, void>> call(String params) async {
    return await authRepository.logout(params);
  }
}

class GetTokenUseCase extends UseCase<void, NoParams> {
  final AuthRepository authRepository;

  GetTokenUseCase({required this.authRepository});
  @override
  Future<Either<Failure, String>> call(NoParams params) async {
    return await authRepository.getToken();
  }
}
