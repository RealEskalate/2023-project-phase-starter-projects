import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/errors/failures/exception.dart';
import '../../../../core/utils/constants.dart';
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
        Uri.parse("$baseApi/user/login"),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(loginUserModel.toJson()));

    if (response.statusCode == 200) {
      final data = json.decode(response.body)['data'];
      final token = json.decode(response.body)['token'].toString();
      return UserDataModel(data: DataModel.fromJson(data), token: token);
      //       Uri.parse("$baseApi/user/login"),
      //       headers: {'Content-Type': 'application/json'},
      //       body: json.encode(loginUserModel.toJson()));

      //   if (response.statusCode == 201) {
      //     var decoddedResponse = json.decode(response.body);

      //     return UserDataModel(
      //         data: Data.fromJson(decoddedResponse['data']),
      //         token: decoddedResponse['token']);
    } else {
      throw ServerException();
    }
  }

  @override
  Future<SignUpModel> signup(SignUpModel signUpModel) async {
    final http.Response response = await client.post(
      Uri.parse("$baseApi/user"),
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
