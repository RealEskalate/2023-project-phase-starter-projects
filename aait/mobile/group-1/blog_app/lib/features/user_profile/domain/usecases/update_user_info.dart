import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/user_entity.dart';
import '../repositories/user_repository.dart';

class UpdateUserImage {
  final UserRepository repository;

  UpdateUserImage(this.repository);

  Future<Either<Failure, User>> call(User user) async {
    return await repository.updateUserImage(user);
  }
}

class NoParams {}
