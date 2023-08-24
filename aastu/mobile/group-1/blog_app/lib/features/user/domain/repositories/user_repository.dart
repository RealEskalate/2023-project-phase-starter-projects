import '../entities/user.dart';

abstract class UserRepository {
  Future<void> registerUser({
    required String fullName,
    required String email,
    required String password,
    required String expertise,
    required String bio,
  });

  Future<User> loginUser({
    required String email,
    required String password,
  });

  Future<User> getUser(String userId);

  Future<void> updateProfilePhoto(
      String userId, String imageUrl, String imagePublicId);
}
