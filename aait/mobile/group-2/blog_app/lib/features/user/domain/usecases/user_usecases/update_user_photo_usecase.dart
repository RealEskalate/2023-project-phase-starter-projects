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
    return await userRepository.updateUserPhoto(params.userId, params.imageUrl);
  }
}

class UpdateUserPhotoParams extends Equatable {
  final String userId;
  final String imageUrl;

  const UpdateUserPhotoParams({required this.userId, required this.imageUrl});

  @override
  List<Object?> get props => [userId, imageUrl];
}
