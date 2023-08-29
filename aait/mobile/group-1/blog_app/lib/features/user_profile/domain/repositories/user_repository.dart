import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/user_entity.dart';

abstract class UserRepository {
  Future<Either<Failure, User>> getUserInfo();
  Future<Either<Failure, User>> updateUserImage(User user);
}
