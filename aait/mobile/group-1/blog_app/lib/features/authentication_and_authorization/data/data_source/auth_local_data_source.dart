abstract class AuthLocalDataSource {
  Future<void> cacheToken(String key, String token);
  Future<String> getToken(String key);
  Future<void> deleteUser(String key);
}
