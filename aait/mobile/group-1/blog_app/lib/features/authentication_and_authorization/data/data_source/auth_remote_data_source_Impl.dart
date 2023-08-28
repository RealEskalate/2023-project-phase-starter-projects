import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/errors/failures/exception.dart';
import '../models/login_user_model.dart';
import '../models/sign_up_user_model.dart';
import '../models/user_data_model.dart';
import 'auth_remote_data_source.dart';

class AuthRemoteDataSourceImpl implements AuthRemoteDataSource {
  final http.Client client;
  AuthRemoteDataSourceImpl({required this.client});

  @override
  Future<UserDataModel> login(LoginUserModel loginUserModel) async {
    final http.Response response = await client.post(
        Uri.parse("https://blog-api-4z3m.onrender.com/api/v1/user/login"),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(loginUserModel.toJson()));

    if (response.statusCode == 200) {
      final data = json.decode(response.body)['data'];
      final token = json.decode(response.body)['token'].toString();
      return UserDataModel(data: DataModel.fromJson(data), token: token);
    } else {
      throw ServerException();
    }
  }

  @override
  Future<SignUpModel> signup(SignUpModel signUpModel) async {
    final http.Response response = await client.post(
      Uri.parse("https://blog-api-4z3m.onrender.com/api/v1/user"),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(signUpModel.toJson()),
    );
    if (response.statusCode == 200) {

      return SignUpModel.fromJson(json.decode(response.body)['data']);
    } else {
      throw ServerException();
    }
  }
}
