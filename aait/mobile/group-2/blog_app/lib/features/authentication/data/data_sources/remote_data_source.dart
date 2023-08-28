import '../../domain/entities/authenticated_user_info.dart';
import '../../domain/entities/authentication_entity.dart';
import '../models/login_model.dart';
import '../models/sign_up_model.dart';

abstract class AuthRemoteDataSource {
  /// Returns [AuthenticationEntity] after a successful login
  ///
  /// Throws a [ServerException] for server errors
  /// Throws  a [LoginException] for login errors
  Future<AuthenticationEntity> login(LoginRequestModel loginRequestModel);

  /// Returns [AuthenticatedUserInfo] after a successful sign up
  ///
  /// Throws a [ServerException] for server errors
  /// Throws a [SignUpException] for sign up errors
  Future<AuthenticatedUserInfo> signUp(SignUpRequestModel signUpRequestModel);

  /// Returns [void] after a successful logout
  ///
  /// Throws a [ServerException] for server errors
  /// Throws a [LogoutException] for logout errors
  Future<void> logout(String token);
}
