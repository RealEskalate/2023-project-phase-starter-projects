import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/error/exception.dart';

abstract class LocalDataSource {
  SharedPreferences get prefs;
  Future<bool> catchToken({required String token});
}

class LocalDataSourceImpl implements LocalDataSource {
  @override
  Future<bool> catchToken({required String token}) async {
    try {
      await prefs.setString('token', token);
      return true;
    } catch (e) {
      return throw CacheException();
    }
  }

  @override
  SharedPreferences prefs;

  LocalDataSourceImpl({required this.prefs});
}
