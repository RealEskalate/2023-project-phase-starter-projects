import 'dart:convert';

import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:http/http.dart' as http;

abstract class ProfileRemoteDataSource {
  Future<Profile> getProfile();
}

class ProfileRemoteDataSourceImpl implements ProfileRemoteDataSource {
  final http.Client client;
  final String url = 'http://localhost:4500/api/v1/user';
  ProfileRemoteDataSourceImpl({required this.client});
  @override
  Future<Profile> getProfile() async {
    final result = await client.get(Uri.parse(url));
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body);
      final ProfileModel profile = ProfileModel.fromJson(jsonResponse);
      return profile;
    } else {
      throw ServerException();
    }
  }
}
