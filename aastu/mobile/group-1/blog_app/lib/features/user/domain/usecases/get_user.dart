import '../entities/user.dart';
import '../repositories/user_repository.dart';

class RegisterUserUseCase {
  final UserRepository repository;

  RegisterUserUseCase(this.repository);

  Future<void> call({
    required String fullName,
    required String email,
    required String password,
    required String expertise,
    required String bio,
  }) async {
    await repository.registerUser(
      fullName: fullName,
      email: email,
      password: password,
      expertise: expertise,
      bio: bio,
    );
  }
}

class LoginUserUseCase {
  final UserRepository repository;

  LoginUserUseCase(this.repository);

  Future<User> call({
    required String email,
    required String password,
  }) async {
    return await repository.loginUser(email: email, password: password);
  }
}

class GetUserUseCase {
  final UserRepository repository;

  GetUserUseCase(this.repository);

  Future<User> call(String userId) async {
    return await repository.getUser(userId);
  }
}

class UpdateProfilePhotoUseCase {
  final UserRepository repository;

  UpdateProfilePhotoUseCase(this.repository);

  Future<void> call(
      String userId, String imageUrl, String imagePublicId) async {
    await repository.updateProfilePhoto(userId, imageUrl, imagePublicId);
  }
}
