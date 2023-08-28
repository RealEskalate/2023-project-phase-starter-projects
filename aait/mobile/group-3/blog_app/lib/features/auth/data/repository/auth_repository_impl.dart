import 'package:dartz/dartz.dart';
import '../../../../core/error/exception.dart';
import '../../../../core/error/failure.dart';
import '../../domain/entity/auth_entitie.dart';
import '../../domain/repository/auth_repository.dart';
import '../data_sources/remote_data_source.dart';
import '../models/auth_entite_model.dart';

class AuthRepositoryImpl extends AuthRepository {
  final AuthRemoteDataSource authRemoteDataSource;

  AuthRepositoryImpl(this.authRemoteDataSource);
  @override
  Future<Either<Failure, bool>> login(
      {required AuthEntitie authEntitie}) async {
    try {
      AuthEntitieModel authEntitieModel = AuthEntitieModel(
          email: authEntitie.email, password: authEntitie.password);
      await authRemoteDataSource.login(authEntitieModel: authEntitieModel);
      return const Right(true);
    } on CacheException {
      return const Left(CacheFailure(
        message: "something went wrong",
        statusCode: 400,
      ));
    } on EmailAndPasswordNotMatchException {
      return const Left(EmailAndPasswordNotMatchFailure(
        message: "your email and password does not match",
        statusCode: 401,
      ));
    } on ServerException catch (e) {
      return Left(
        ServerFailure(
          message: "the server does not work know",
          statusCode: e.statusCode,
        ),
      );
    } on NetworkConnectionException {
      return const Left(NetworkConnectionFailure(
        message: "there is no connection",
        statusCode: 400,
      ));
    }
  }

  @override
  Future<Either<Failure, bool>> signup(
      {required AuthEntitie authEntitie}) async {
    try {
      AuthEntitieModel authEntitieModel = AuthEntitieModel(
        email: authEntitie.email,
        password: authEntitie.password,
        fullName: authEntitie.fullName,
        bio: authEntitie.bio,
        expertise: authEntitie.expertise,
      );
      await authRemoteDataSource.signup(authEntitieModel: authEntitieModel);
      return const Right(true);
    } on EmailAndPasswordNotMatchException {
      return const Left(EmailAndPasswordNotMatchFailure(
        message: "your email and password does not match",
        statusCode: 400,
      ));
    } on ServerException catch (e) {
      return Left(
        ServerFailure(
          message: "the server does not work know",
          statusCode: e.statusCode,
        ),
      );
    } on NetworkConnectionException {
      return const Left(NetworkConnectionFailure(
        message: "there is no connection",
        statusCode: 400,
      ));
    }
  }
}
