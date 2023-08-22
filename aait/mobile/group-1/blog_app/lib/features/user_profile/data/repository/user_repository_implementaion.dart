import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/user_profile/domain/entities/user_entity.dart';
import 'package:blog_app/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class UserRepositoryImpl extends UserRepository {
  @override
  Future<Either<Failure, User>> getUserInfo() {
    // TODO: implement getUserInfo
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, User>> updateUserInfo() {
    // TODO: implement updateUserInfo
    throw UnimplementedError();
  }
}
