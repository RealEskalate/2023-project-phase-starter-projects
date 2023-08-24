import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entity/auth_entitie.dart';

abstract class AuthRepository {
  Future<Either<Failure, bool>> login({required AuthEntitie authEntitie});
  Future<Either<Failure, bool>> signup({required AuthEntitie authEntitie});
}
