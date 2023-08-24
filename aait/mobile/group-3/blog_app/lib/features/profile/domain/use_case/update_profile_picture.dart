import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:dartz/dartz.dart';

class UpdateProfilePicture extends UseCase<Profile, Params> {
  final ProfileRepository repository;

  UpdateProfilePicture({required this.repository});
  @override
  Future<Either<Failure, Profile>> call(Params params) async {
    return await repository.updateProfilePicture(params.data);
  }
}
