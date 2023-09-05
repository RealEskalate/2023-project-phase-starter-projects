import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:image_picker/image_picker.dart';

class UpdateProfilePicture extends UseCase<Profile, UpdateProfileParams> {
  final ProfileRepository repository;

  UpdateProfilePicture({required this.repository});
  @override
  Future<Either<Failure, Profile>> call(UpdateProfileParams params) async {
    return await repository.updateProfilePicture(image: params.image, userId: params.userId);
  }
}

class UpdateProfileParams extends Equatable {
  final String userId;
  final XFile image;

  UpdateProfileParams({required this.image, required this.userId});

  @override
  List<Object> get props => [userId, image];
}