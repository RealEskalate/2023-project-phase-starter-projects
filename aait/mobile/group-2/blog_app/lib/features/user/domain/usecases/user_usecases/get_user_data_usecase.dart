import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../../core/error/failure.dart';
import '../../../../../core/usecase/usecase.dart';
import '../../entities/user_data.dart';
import '../../repositories/user_repository.dart';

class GetUserData implements UseCase<UserData, GetUserDataParams> {
  final UserRepository userRepository;

  GetUserData(this.userRepository);

  @override
  Future<Either<Failure, UserData>> call(GetUserDataParams params) async {
    return await userRepository.getUserData(params.token);
  }
}

class GetUserDataParams extends Equatable {
  final String token;

  const GetUserDataParams({required this.token});

  @override
  List<Object?> get props => [token];
}