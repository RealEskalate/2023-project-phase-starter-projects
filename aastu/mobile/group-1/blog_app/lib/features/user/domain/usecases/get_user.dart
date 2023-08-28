import 'package:blog_app/core/error/failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/user.dart';
import '../repositories/user_repository.dart';

class GetUserUseCase {
  final UserRepository repository;

  GetUserUseCase(this.repository);

  Future<Either<Failure, User>> call(String userId) async {
    try {
      final user = await repository.getUser(userId);
      return Right(user as User); // Return user as Right with success case
    } catch (e) {
      return const Left(ServerFailure('Error fetching user'));
    }
  }
}
