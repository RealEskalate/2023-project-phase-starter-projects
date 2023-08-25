import 'dart:convert';

import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

abstract class ProfileRemoteDataSource {
  Future<Profile> getProfile();
}

class ProfileRemoteDataSourceImpl implements ProfileRemoteDataSource {
  final http.Client client;
  final String url = 'https://blog-api-4z3m.onrender.com/api/v1/user';
  ProfileRemoteDataSourceImpl({required this.client});
  @override
  Future<Profile> getProfile() async {
  final token = await getStoredToken();
    final result = await client
        .get(Uri.parse(url), headers: {"Authorization": "Bearer $token"});
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body);
      final ProfileModel profile = ProfileModel.fromJson(jsonResponse);
      return profile;
    }  else {
      throw ServerException(statusCode: 400);
    }
  }

  Future<String> getStoredToken() async {
    final SharedPreferences pref = await SharedPreferences.getInstance();
    final String token = pref.getString('token')!;
    return token;
  }
}
