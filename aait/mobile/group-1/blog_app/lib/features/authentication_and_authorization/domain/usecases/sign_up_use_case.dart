import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/sign_up_user_entity.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/user_data_entity.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/repositories/auth_repository.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/user_use_case.dart';
import 'package:dartz/dartz.dart';


class SignUpUseCase implements UseCase<UserDataEntity, SignUpUserEnity> {
  final AuthRepository repository;
  SignUpUseCase({required this.repository});

  @override
  Future<Either<Failure, UserDataEntity>> call(
      SignUpUserEnity signUpUserEnity) async {
    return await repository.signup(signUpUserEnity);
  }
}
