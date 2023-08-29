import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/authenticated_user_info.dart';
import '../entities/authentication_entity.dart';
import '../entities/login_entity.dart';
import '../entities/sign_up_entity.dart';

abstract class AuthRepository {
  Future<Either<Failure, AuthenticationEntity>> login(
      LoginRequestEntity loginRequestEntity);
  Future<Either<Failure, AuthenticatedUserInfo>> signUp(
      SignUpEntity signUpEntity);

  Future<Either<Failure, void>> logout(String token);
  Future<Either<Failure, String>> getToken();
}
