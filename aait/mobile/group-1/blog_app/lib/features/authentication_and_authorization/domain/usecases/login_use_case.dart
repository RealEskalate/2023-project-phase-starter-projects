import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/repositories/auth_repository.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/user_use_case.dart';
import 'package:dartz/dartz.dart';


class Login_UseCase implements UseCase<LoginUserEnity, LoginUserEnity> {
  final AuthRepository repository;
  Login_UseCase({required this.repository});

  @override
  Future<Either<Failure, LoginUserEnity>> call(
      LoginUserEnity loginUserEnity) async {
    return await repository.login(loginUserEnity);
  }
}