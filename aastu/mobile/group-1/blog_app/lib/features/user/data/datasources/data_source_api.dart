import 'package:blog_app/features/user/domain/entities/user.dart';

abstract class UserRemoteDataSource {
  Future<void> registerUser(Map<String, dynamic> userData);
  Future<Map<String, dynamic>> loginUser(Map<String, dynamic> loginData);
  Future<User> getUser();
  Future<void> updateProfilePhoto(
      String userId, String imageUrl, String imagePublicId);
}

abstract class UserLocalDataSource {
  Future<void> saveUserData(User user);
  Future<User?> getUserData();
  Future<void> clearUserData();
}
