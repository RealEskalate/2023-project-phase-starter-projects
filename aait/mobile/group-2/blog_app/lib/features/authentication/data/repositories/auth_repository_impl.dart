import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failure.dart';
import '../../domain/entities/authenticated_user_info.dart';
import '../../domain/entities/authentication_entity.dart';
import '../../domain/entities/login_entity.dart';
import '../../domain/entities/sign_up_entity.dart';
import '../../domain/repositories/auth_repo.dart';
import '../data_sources/local_data_source.dart';
import '../data_sources/remote_data_source.dart';
import '../models/authenticated_user_info_model.dart';
import '../models/login_model.dart';
import '../models/sign_up_model.dart';

class AuthRepositoryImpl implements AuthRepository {
  final AuthLocalDataSource authLocalDataSource;
  final AuthRemoteDataSource authRemoteDataSource;

  AuthRepositoryImpl({
    required this.authLocalDataSource,
    required this.authRemoteDataSource,
  });
  @override
  Future<Either<Failure, AuthenticationEntity>> login(
      LoginRequestEntity loginRequestEntity) async {
    try {
      final LoginRequestModel loginRequestModel = LoginRequestModel(
          email: loginRequestEntity.email,
          password: loginRequestEntity.password);
      final authenticationEntity =
          await authRemoteDataSource.login(loginRequestModel);
      final AuthenticatedUserInfo authenticatedUserInfo =
          authenticationEntity.authenticatedUserInfo;
      final AuthenticatedUserInfoModel authenticatedUserInfoModel =
          AuthenticatedUserInfoModel(
        fullName: authenticatedUserInfo.fullName,
        email: authenticatedUserInfo.email,
        expertise: authenticatedUserInfo.expertise,
        bio: authenticatedUserInfo.bio,
        image: authenticatedUserInfo.image,
        imageCloudinaryPublicId: authenticatedUserInfo.imageCloudinaryPublicId,
      );

      await authLocalDataSource.cacheLoggedInUser(authenticatedUserInfoModel);
      await authLocalDataSource.cacheToken(authenticationEntity.token);
      return Right(authenticationEntity);
    } on ServerException catch (e) {
      // print the error message for debugging
      debugPrint(e.toString());
      return const Left(ServerFailure(message: 'Server Error'));
    }
  }

  @override
  Future<Either<Failure, AuthenticatedUserInfo>> signUp(
      SignUpEntity signUpEntity) async {
    try {
      final SignUpRequestModel signUpRequestModel = SignUpRequestModel(
          email: signUpEntity.email,
          password: signUpEntity.password,
          fullName: signUpEntity.fullName,
          expertise: signUpEntity.expertise,
          bio: signUpEntity.bio);
      final authenticatedUserInfo =
          await authRemoteDataSource.signUp(signUpRequestModel);
      return Right(authenticatedUserInfo);
    } on ServerException catch (e) {
      // print the error message for debugging
      debugPrint(e.toString());
      return const Left(ServerFailure(message: 'Server Error'));
    }
  }

  @override
  Future<Either<Failure, void>> logout(String token) async {
    try {
      final result = await authRemoteDataSource.logout(token);
      await authLocalDataSource.deleteLoggedInUser();
      return Right(result);
    } on ServerException catch (e) {
      // print the error message for debugging
      debugPrint(e.toString());
      return const Left(ServerFailure(message: 'Server Error'));
    }
  }
}
