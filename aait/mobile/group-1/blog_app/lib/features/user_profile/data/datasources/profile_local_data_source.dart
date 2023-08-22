import 'package:blog_app/features/user_profile/data/models/user_model.dart';

abstract class ProfileLocalDataSource {
  Future<UserModel> getUserInfo();
  Future<UserModel> updateUserInfo();
}

class ProfileLocalDataSourceImpl extends ProfileLocalDataSource {
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
