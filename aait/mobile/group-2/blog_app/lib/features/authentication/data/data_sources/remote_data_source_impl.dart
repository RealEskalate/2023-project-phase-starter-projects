// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/error/exception.dart';
import '../models/authenticated_user_info_model.dart';
import '../models/authentication_model.dart';
import '../models/login_model.dart';
import '../models/sign_up_model.dart';
import 'remote_data_source.dart';

class AuthRemoteDataSourceImpl extends AuthRemoteDataSource {
  final http.Client client;
  AuthRemoteDataSourceImpl({
    required this.client,
  });

  @override
  Future<AuthenticationModel> login(LoginRequestModel loginRequestModel) async {
    final http.Response response = await client.post(
        Uri.parse('http://localhost:3000/login'),
        body: jsonEncode(loginRequestModel.toJson()),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      final responseBody = jsonDecode(response.body);
      return AuthenticationModel.fromJson(responseBody);
    } else {
      // throw LoginException();
      throw const ServerException(message: 'Server Error');
    }
  }

  @override
  Future<AuthenticatedUserInfoModel> signUp(
      SignUpRequestModel signUpRequestModel) async {
    final http.Response response = await client.post(
        Uri.parse('http://localhost:3000/signup'),
        body: jsonEncode(signUpRequestModel.toJson()),
        headers: {'Content-Type': 'application/json'});
    if (response.statusCode == 200) {
      final responseBody = jsonDecode(response.body);
      return AuthenticatedUserInfoModel.fromJson(responseBody['data']);
    } else {
      // throw SignUpException();
      throw const ServerException(message: 'Server Error');
    }
  }

  @override
  Future<void> logout(String token) async {
    final http.Response response = await client.post(
        Uri.parse('http://localhost:3000/logout'),
        body: jsonEncode({'token': token}),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      return;
    } else {
      // throw LogoutException();
      throw const ServerException(message: 'Server Error');
    }
  }
}
