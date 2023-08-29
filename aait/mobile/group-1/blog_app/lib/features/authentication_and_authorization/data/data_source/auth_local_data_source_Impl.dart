import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/errors/failures/exception.dart';
import '../models/user_data_model.dart';
import 'auth_local_data_source.dart';

const token_key = "token";
const user_key = "user";

class LocalDataSourceImpl implements AuthLocalDataSource {
  final SharedPreferences sharedPreferences;
  LocalDataSourceImpl({required this.sharedPreferences});
// use constant for key
  @override
  Future<void> cacheToken(String token) {
    return sharedPreferences.setString(token_key, token);
  }

// use constant for key
  @override
  Future<void> deleteUser() {
    sharedPreferences.remove(user_key);
    return sharedPreferences.remove(token_key);
  }

  @override
  Future<String> getToken() {
    final jsonString = sharedPreferences.getString(token_key);
    if (jsonString != null) {
      return Future.value(jsonString);
    } else {
      throw CacheException();
    }
  }

  @override
  Future<void> setUser(DataModel userDataModel) {
    return sharedPreferences.setString(
        user_key, json.encode(userDataModel.toJson()));
  }

  @override
  Future<DataModel> getUser() {
    final jsonString = sharedPreferences.getString(user_key);
    if (jsonString != null) {
      final jsonuser = json.decode(jsonString);
      return Future.value(DataModel.fromJson(jsonuser));
    } else {
      throw CacheException();
    }
  }
}
