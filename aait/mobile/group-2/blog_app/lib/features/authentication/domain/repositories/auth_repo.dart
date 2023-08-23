import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../user/domain/entities/user_data.dart';
import '../entities/login_entity.dart';
import '../entities/sign_up_entity.dart';

abstract class AuthRepository {
  Future<Either<Failure, UserData>> signIn(SignUpEntity signUpEntity);

  Future<Either<Failure, UserData>> login(
      LoginRequestEntity loginRequestEntity);

  Future<Either<Failure, void>> logout(String token);
}
