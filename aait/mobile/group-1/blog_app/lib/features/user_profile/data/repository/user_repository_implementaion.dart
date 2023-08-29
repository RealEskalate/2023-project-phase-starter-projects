import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/user_profile/data/datasources/profile_local_data_source.dart';
import 'package:blog_app/features/user_profile/data/datasources/profile_remote_data_source.dart';
import 'package:blog_app/features/user_profile/domain/entities/user_entity.dart';
import 'package:blog_app/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/network/network_info.dart';

class UserRepositoryImpl extends UserRepository {
  final NetworkInfo networkInfo;
  final ProfileRemoteDataSource remoteDataSource;
  final ProfileLocalDataSource localDataSource;

  UserRepositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, User>> getUserInfo() async {
    final isConnected = await networkInfo.isConnected;
    if (isConnected) {
      try {
        final user = await remoteDataSource.getUserInfo();
        return Right(user);
      } catch (e) {
        print("error occured $e");
        return Left(ServerFailure(message: e.toString()));
      }
    } else {
      try {
        final user = await localDataSource.getUserInfo();
        return Right(user);
      } catch (e) {
        print("error occured $e");
        return Left(ServerFailure(message: e.toString()));
      }
    }
  }

  @override
  Future<Either<Failure, User>> updateUserImage(User user) async {
    try {
      final userNew = await remoteDataSource.updateUserImage(user);
      return Right(userNew);
    } catch (e) {
      print("error occured $e");
      return Left(ServerFailure(message: e.toString()));
    }
  }
}
