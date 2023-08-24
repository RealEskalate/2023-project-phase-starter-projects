import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:blog_app/features/authentication_and_authorization/data/data_source/auth_local_data_source.dart';
import 'package:shared_preferences/shared_preferences.dart';

class LocalDataSourceImpl implements AuthLocalDataSource {
  final SharedPreferences sharedPreferences;
  LocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheToken(String key, String token) {
    return sharedPreferences.setString(key, token);
  }

  @override
  Future<void> deleteUser(String key) {
    return sharedPreferences.remove(key);
  }

  @override
  Future<String> getToken(String key) {
    final jsonString = sharedPreferences.getString(key);
    if (jsonString != null) {
      return Future.value(jsonString);
    } else {
      throw CacheException();
    }
  }
}
