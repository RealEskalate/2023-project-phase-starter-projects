import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/sign_up_user_entity.dart';
import '../repositories/auth_repository.dart';
import 'user_use_case.dart';


class SignUpUseCase implements UseCase<SignUpUserEnity, SignUpUserEnity> {
  final AuthRepository repository;
  SignUpUseCase({required this.repository});

  @override
  Future<Either<Failure, SignUpUserEnity>> call(
      SignUpUserEnity signUpUserEnity) async {
    return await repository.signup(signUpUserEnity);
  }
}
