import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/user_entity.dart';
import '../repositories/user_repository.dart';

class UpdateUserInfo {
  final UserRepository repository;

  UpdateUserInfo(this.repository);

  Future<Either<Failure, User>> call(NoParams params) async {
    return await repository.updateUserInfo();
  }
}

class NoParams {}
