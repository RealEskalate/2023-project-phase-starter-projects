import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/login_user_entitiy.dart';
import '../entities/sign_up_user_entity.dart';
import '../entities/user_data_entity.dart';


abstract class AuthRepository {


  Future<Either<Failure, SignUpUserEnity>> signup( SignUpUserEnity signUpUserEnity);


  Future<Either<Failure, UserDataEntity>> login(LoginUserEnity loginUserEnity);
}
