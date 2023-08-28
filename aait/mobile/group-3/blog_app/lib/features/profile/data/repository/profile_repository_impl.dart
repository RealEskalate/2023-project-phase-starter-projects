import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/core/network/network_info.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_local_data_source.dart';
import 'package:blog_app/features/profile/data/data_sources/profile_remote_data_source.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:image_picker/image_picker.dart';

class ProfileRepositoryImpl implements ProfileRepository {
  final NetworkInfo networkInfo;
  final ProfileLocalDataSource localDataSource;
  final ProfileRemoteDataSource remoteDataSource;

  ProfileRepositoryImpl(
      {required this.networkInfo,
      required this.localDataSource,
      required this.remoteDataSource});
  @override
  Future<Either<Failure, Profile>> getProfile() async {
    try {
      final remoteProfile = await remoteDataSource.getProfile();
      final bookmarks = await localDataSource.getBookmarkArticles();
      return Right(remoteProfile.copyWith(bookmarks: bookmarks));
    } on ServerException {
      return Left(ServerFailure(
          message: "Couldn't connect to the internet", statusCode: 400));
    }
  }

  @override
  Future<Either<Failure, Profile>> updateProfilePicture(XFile image) async {
    try {
      final remoteProfile = await remoteDataSource.updateProfilePicture(image);
      final bookmarks = await localDataSource.getBookmarkArticles();
      return Right(remoteProfile.copyWith(bookmarks: bookmarks));
    } on ServerException {
      return Left(ServerFailure(
          message: "Update profile picture failed", statusCode: 400));
    }
  }
}
