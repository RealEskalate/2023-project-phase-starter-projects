import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/user_entity.dart';
import '../repositories/user_repository.dart';

class GetUserInfo {
  final UserRepository repository;
  GetUserInfo(this.repository);

  Future<Either<Failure, User>> call() async {
    return await repository.getUserInfo();
  }
}
