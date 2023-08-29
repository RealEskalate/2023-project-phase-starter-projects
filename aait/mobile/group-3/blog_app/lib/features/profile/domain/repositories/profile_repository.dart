import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:dartz/dartz.dart';
import 'package:image_picker/image_picker.dart';

abstract class ProfileRepository {
  Future<Either<Failure, Profile>> getProfile();
  Future<Either<Failure, Profile>> updateProfilePicture(XFile image);
}
