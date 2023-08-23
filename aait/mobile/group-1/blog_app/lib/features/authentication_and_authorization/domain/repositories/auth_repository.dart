import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/login_user_entitiy.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/entities/sign_up_user_entity.dart';
import 'package:dartz/dartz.dart';


abstract class AuthRepository {


  Future<Either<Failure, SignUpUserEnity>> signup( SignUpUserEnity signUpUserEnity);


  Future<Either<Failure, LoginUserEnity>> login(LoginUserEnity loginUserEnity);
}
