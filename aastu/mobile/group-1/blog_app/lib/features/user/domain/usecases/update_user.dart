import 'package:blog_app/core/error/failure.dart';
import 'package:dartz/dartz.dart';

import '../repositories/user_repository.dart';

class UpdateProfilePhotoUseCase {
  final UserRepository repository;

  UpdateProfilePhotoUseCase(this.repository);

  Future<Either<Failure, void>> call(
      String userId, String imageUrl, String imagePublicId) async {
    try {
      await repository.updateProfilePhoto(userId, imageUrl, imagePublicId);
      return Right(null); // Return success as Right with null value
    } catch (e) {
      return Left(ServerFailure('Error updating profile photo'));
    }
  }
}
