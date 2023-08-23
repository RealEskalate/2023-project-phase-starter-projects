import 'dart:convert';

import 'package:blog_app/core/utils/constants.dart';
import 'package:blog_app/features/user_profile/data/models/user_model.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

abstract class ProfileRemoteDataSource {
  Future<UserModel> getUserInfo();
  Future<UserModel> updateUserInfo();
}

class ProfileRemoteDataSourceImpl extends ProfileRemoteDataSource {
  @override
  Future<UserModel> getUserInfo() async {
    final String? token = await getToken();
    final response = await http
        .get(Uri.parse('$baseApi/users'), headers: {"token": token ?? ""});

    print(response.body);
    final data = jsonDecode(response.body);
    final user = UserModel.fromJson(data);

    return user;
  }

  @override
  Future<UserModel> updateUserInfo() {
    // TODO: implement updateUserInfo
    throw UnimplementedError();
  }

  Future<String?> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString('token');
  }
}
