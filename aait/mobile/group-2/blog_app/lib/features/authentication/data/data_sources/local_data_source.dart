import '../models/authenticated_user_info_model.dart';

abstract class AuthLocalDataSource {
  /// Caches a [token] in the local data source
  ///
  /// Throws a [CacheException] for cache errors
  Future<void> cacheToken(String token);

  Future<void> removeToken();

  /// Gets the cached token from the local data source
  ///
  /// Throws a [CacheException] for cache errors
  Future<String> getToken();

  /// Caches a [AuthenticatedUserInfoModel] in the local data source
  ///
  /// Throws a [CacheException] for cache errors
  Future<void> cacheLoggedInUser(AuthenticatedUserInfoModel userToCache);

  /// Gets the cached user from the local data source
  ///
  /// Throws a [CacheException] for cache errors
  Future<AuthenticatedUserInfoModel> getLoggedInUser();

  /// Deletes the cached user  and it's data from the local data source
  ///
  /// Throws a [CacheException] for cache errors
  Future<void> deleteLoggedInUser();
}
