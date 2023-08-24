import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../../core/error/failure.dart';
import '../../../../../core/usecase/usecase.dart';
import '../../entities/user_data.dart';
import '../../repositories/user_repository.dart';

class UpdateUserPhoto implements UseCase<UserData, UpdateUserPhotoParams> {
  final UserRepository userRepository;

  UpdateUserPhoto(this.userRepository);

  @override
  Future<Either<Failure, UserData>> call(params) async {
    return await userRepository.updateUserPhoto(params.token, params.imagePath);
  }
}

class UpdateUserPhotoParams extends Equatable {
  final String token;
  final String imagePath;

  const UpdateUserPhotoParams({required this.token, required this.imagePath});

  @override
  List<Object?> get props => [token, imagePath];
}
