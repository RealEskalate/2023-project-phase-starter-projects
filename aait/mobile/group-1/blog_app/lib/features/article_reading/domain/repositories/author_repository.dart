import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/user_entity.dart';

abstract class AuthorRepository {
  Future<Either<Failure, User>> getAuthorInfo(id);
}
