import 'package:blog_application/core/exceptions/Failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/user.dart';
abstract class AuthRepository {
  Future<Either<void, Failure>> login(String email, String password);
  Future<void> logout();
  Future<Either<void, Failure>> register(String email, String password, [String? bio, String? fullName, String? expertise]);
  Future<bool> isLoggedIn();
  Future<User> getCurrentUser();
}