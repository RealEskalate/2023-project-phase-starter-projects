import '../../domain/entities/user_data.dart';

abstract class UserRemoteDataSource {
  Future<UserData> getUserData(String token);
  Future<UserData> updateUserPhoto(String token, String imagePath);
}
