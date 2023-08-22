import 'package:dartz/dartz.dart';

import '../../../../../core/error/failure.dart';
import '../../entities/auth/login_entity.dart';
import '../../entities/auth/sign_up_entity.dart';
import '../../entities/user_data.dart';

abstract class AuthRepository {
  Future<Either<Failure, UserData>> signIn(SignUpEntity signUpEntity);

  Future<Either<Failure, UserData>> login(
      LoginRequestEntity loginRequestEntity);

  Future<Either<Failure, void>> logout(String token);
}
