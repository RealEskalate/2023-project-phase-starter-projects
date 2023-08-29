import 'package:dartz/dartz.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failure.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/user_data.dart';
import '../../domain/repositories/user_repository.dart';
import '../datasources/local/user_local_data_source.dart';
import '../datasources/user_remote_data_source.dart';
import '../models/user_data_model.dart';

class UserRespositoryImpl extends UserRepository {
  final UserLocalDataSource localDataSource;
  final UserRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  UserRespositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, UserData>> getUserData(String token) async {
    if (await networkInfo.isConnected) {
      try {
        final user = await remoteDataSource.getUserData(token);

        await localDataSource.cacheUserData(user as UserDataModel);
        return Right(user);
      } catch (e) {
        try {
          final user = await localDataSource.getUserData();
          return Right(user);
        } catch (e) {
          return Left(CacheFailure());
        }
      }
    } else {
      try {
        final user = await localDataSource.getUserData();
        return Right(user);
      } catch (e) {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, UserData>> updateUserPhoto(
      String token, String imagePath) async {
    if (await networkInfo.isConnected) {
      try {
        final uploadedPhoto =
            await remoteDataSource.updateUserPhoto(token, imagePath);
        return Right(uploadedPhoto);
      } on ServerException {
        return Left(ServerFailure());
      } on NetworkException {
        return Left(NetworkFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
