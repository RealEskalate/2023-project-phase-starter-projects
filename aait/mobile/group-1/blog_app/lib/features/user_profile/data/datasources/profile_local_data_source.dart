import 'dart:convert';

import 'package:blog_app/features/user_profile/data/models/user_model.dart';
import 'package:shared_preferences/shared_preferences.dart';

abstract class ProfileLocalDataSource {
  Future<UserModel> getUserInfo();
}

class ProfileLocalDataSourceImpl extends ProfileLocalDataSource {
  @override
  Future<UserModel> getUserInfo() async {
    final prefs = await SharedPreferences.getInstance();
    final encodedUserInfo = prefs.getString("user_info") ?? "";
    return UserModel.fromJson(jsonDecode(encodedUserInfo));
  }
}
