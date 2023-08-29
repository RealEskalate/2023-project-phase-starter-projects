import '../models/user_data_model.dart';

abstract class AuthLocalDataSource {
  Future<void> cacheToken(String token);
  Future<String> getToken();
  Future<void> deleteUser();
  Future<void> setUser(DataModel userDataModel);
  Future<DataModel> getUser();
}
