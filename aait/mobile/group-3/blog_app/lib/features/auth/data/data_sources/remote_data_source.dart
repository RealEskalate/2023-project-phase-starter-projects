import 'dart:convert';
import 'package:blog_app/core/network/network_info.dart';
import 'package:http/http.dart' as http;

import '../../../../core/error/exception.dart';
import '../models/auth_entite_model.dart';
import 'local_data_source.dart';

abstract class AuthRemoteDataSource {
  LocalDataSource get localDataSource;
  NetworkInfo get networkInfo;
  Future<bool> login({required AuthEntitieModel authEntitieModel});
  Future<bool> signup({required AuthEntitieModel authEntitieModel});
}

class AuthRemoteDataSourceImpl implements AuthRemoteDataSource {
  @override
  final LocalDataSource localDataSource;

  @override
  final NetworkInfo networkInfo;

  AuthRemoteDataSourceImpl({
    required this.networkInfo,
    required this.localDataSource,
  });

  @override
  Future<bool> login({required AuthEntitieModel authEntitieModel}) async {
    if (await networkInfo.isConnected) {
      var url =
          Uri.parse('https://blog-api-4z3m.onrender.com/api/v1/user/login');
      var response = await http.post(url,
          body: authEntitieModel.toJsonLogin(),
          headers: {"content": "application/json"});

      if (response.statusCode == 200) {
        if (jsonDecode(response.body)['success']) {
          try {
            await localDataSource.catchToken(
                token: jsonDecode(response.body)['token']);

            return true;
          } on CacheException {
            return throw CacheException();
          }
        } else {
          return throw EmailAndPasswordNotMatchException();
        }
      } else {
        return throw ServerException(
          statusCode: response.statusCode,
          message: "Something went wrong please try again",
        );
      }
    } else {
      return throw NetworkConnectionException();
    }
  }

  @override
  Future<bool> signup({required AuthEntitieModel authEntitieModel}) async {
    if (await networkInfo.isConnected) {
      var url = Uri.parse('https://blog-api-4z3m.onrender.com/api/v1/user');
      var response = await http.post(url,
          body: authEntitieModel.toJsonSignup(),
          headers: {"content": "application/json"});

      if (response.statusCode == 200) {
        if (jsonDecode(response.body)['success']) {
          return true;
        } else {
          return throw EmailAndPasswordNotMatchException();
        }
      } else {
        return throw ServerException(
          statusCode: response.statusCode,
          message: "Something went wrong please try again",
        );
      }
    } else {
      return throw NetworkConnectionException();
    }
  }
}
