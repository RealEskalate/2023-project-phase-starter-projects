import 'dart:convert';

import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:blog_app/features/authentication_and_authorization/data/data_source/auth_remote_data_source.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/login_user_model.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/sign_up_user_model.dart';
import 'package:blog_app/features/authentication_and_authorization/data/models/user_data_model.dart';
import 'package:http/http.dart' as http;

class AuthRemoteDataSourceImpl implements AuthRemoteDataSource {
  final http.Client client;
  AuthRemoteDataSourceImpl({required this.client});

  @override
  Future<UserDataModel> login(LoginUserModel loginUserModel) async {
    final http.Response response = await client.post(
        Uri.parse("http://localhost:4500/api/v1/user/login"),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(loginUserModel.toJson()));

    if (response.statusCode == 201) {
      var decoddedResponse = json.decode(response.body);

      return UserDataModel(
          data: Data.fromJson(decoddedResponse['data']),
          token: decoddedResponse['token']
          );
    } else {
      throw ServerException();
    }
  }

  @override
  Future<UserDataModel> signup(SignUpModel signUpModel) async {
    final http.Response response = await client.post(
      Uri.parse("http://localhost:4500/api/v1/user"),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(signUpModel.toJson()),
    );

    if (response.statusCode == 201) {
      return UserDataModel(
          data: Data.fromJson(jsonDecode(response.body)['data']),
          token: jsonDecode(response.body)['token']);
    } else {
      throw ServerException();
    }
  }
}
