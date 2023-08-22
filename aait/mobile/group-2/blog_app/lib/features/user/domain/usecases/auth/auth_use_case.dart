import 'package:dartz/dartz.dart';


import '../../entities/auth/login_entity.dart';
import '../../entities/auth/sign_up_entity.dart';

import '../../repositories/auth/auth_repo.dart';

abstract class UseCase<Type, Params> {
  Future<Either<Failure, Type>> call(Params params);
}

class LoginUseCase extends UseCase<UserData, LoginRequestEntity> {
  final AuthRepository authRepository;
  LoginUseCase({required this.authRepository});
  @override
  Future<Either<Failure, UserData>> call(LoginRequestEntity params) {
    // TODO: implement call
    throw UnimplementedError();
  }
}

class SignUpUseCase extends UseCase<UserData, SignUpEntity> {
  final AuthRepository repository;

  SignUpUseCase({required this.repository});

  @override
  Future<Either<Failure, UserData>> call(SignUpEntity params) {
    // TODO: implement call
    throw UnimplementedError();
  }
}
