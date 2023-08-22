import 'package:blog_app/features/user_profile/data/models/user_model.dart';

abstract class ProfileRemoteDataSource {
  Future<UserModel> getUserInfo();
  Future<UserModel> updateUserInfo();
}

class ProfileRemoteDataSourceImpl extends ProfileRemoteDataSource {
  @override
  Future<UserModel> getUserInfo() {
    // TODO: implement getUserInfo
    throw UnimplementedError();
  }

  @override
  Future<UserModel> updateUserInfo() {
    // TODO: implement updateUserInfo
    throw UnimplementedError();
  }
}
