import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/core/network/network_info.dart';
import 'package:blog_app/features/authentication_and_authorization/data/data_source/auth_local_data_source.dart';
import 'package:blog_app/features/authentication_and_authorization/data/data_source/auth_remote_data_source.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/login_user_model.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/sign_up_user_model.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/sign_up_user_entity.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/repositories/auth_repository.dart';
import 'package:dartz/dartz.dart';


class AuthRepositoryImpl extends AuthRepository {
  final AuthRemoteDataSource authRemoteDataSource;
  final AuthLocalDataSource authLocalDataSource;
  final NetworkInfo networkInfo;
  AuthRepositoryImpl(
      {required this.authLocalDataSource,
      required this.authRemoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, SignUpUserEnity>> signup(
      SignUpUserEnity signUpUserEnity) async {
    if (await networkInfo.isConnected) {
      try {
        SignUpModel newUserModel = SignUpModel(
            id: signUpUserEnity.id,
            fullName: signUpUserEnity.fullName,
            email: signUpUserEnity.email,
            password: signUpUserEnity.password,
            expertise: signUpUserEnity.expertise,
            bio: signUpUserEnity.bio,
            image: signUpUserEnity.image);
        final remoteSignup = await authRemoteDataSource.signup(newUserModel);

        return Right(remoteSignup);
      } on ServerException catch (e) {
        return Left(ServerFailure(message: "Server Error"));
      }
    } else {
      return Left(ConnectionFailure(message: "No Internet Connection"));
    }
  }

  @override
  Future<Either<Failure, LoginUserEnity>> login(LoginUserEnity loginUserEnity) async{

    if(await networkInfo.isConnected){

      try{
        LoginUserModel loginUserModel=LoginUserModel(
          email: loginUserEnity.email, 
          password: loginUserEnity.password);
      final remotelogin=await authRemoteDataSource.login(loginUserModel);

      return Right(remotelogin);

      }on ServerException catch (e) {
        return Left(ServerFailure(message: "Server Error"));
      }
    } else {
      return Left(ConnectionFailure(message: "No Internet Connection"));
    }
      
    }


  }

