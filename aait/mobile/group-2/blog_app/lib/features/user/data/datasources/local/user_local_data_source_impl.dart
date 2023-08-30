import 'dart:convert';

import 'package:blog_app/features/user/data/datasources/local/user_local_data_source.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../../core/error/exception.dart';
import '../../../../article/data/models/article_model.dart';
import '../../models/user_data_model.dart';

const CACHED_BOOKMARKED_ARTICLES = 'CACHED_BOOKMARKED_ARTICLES';
const _keyToken = 'token';
const CACHED_USER_DATA = 'CACHED_USER_DATA';

class UserLocalDataSourceImpl implements UserLocalDataSource {
  final SharedPreferences sharedPreferences;

  UserLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheBookmarkedArticles(List<ArticleModel> articlesToCache) {
    final articleJsonList =
        articlesToCache.map((article) => article.toJson()).toList();
    final jsonStringList =
        articleJsonList.map((json) => jsonEncode(json)).toList();
    return sharedPreferences.setStringList(
        CACHED_BOOKMARKED_ARTICLES, jsonStringList);
  }

  @override
  Future<List<ArticleModel>> getAllBookmarkedArticles() async {
    final jsonStringList =
        sharedPreferences.getStringList(CACHED_BOOKMARKED_ARTICLES);

    if (jsonStringList != null) {
      final articleJsonList =
          jsonStringList.map((json) => jsonDecode(json)).toList();
      final articles =
          articleJsonList.map((json) => ArticleModel.fromJson(json)).toList();
      return articles;
    } else {
      throw const CacheException(message: 'No bookmarked articles found');
    }
  }

  @override
  Future<void> removeBookmark(String articleId) async {
    final bookmarks = await getAllBookmarkedArticles();

    final filteredBookmarks =
        bookmarks.where((bookmark) => (bookmark.id) != articleId);

    await cacheBookmarkedArticles(filteredBookmarks.toList());
  }

  @override
  Future<void> cacheToken(String token) {
    return sharedPreferences.setString(_keyToken, token);
  }

  @override
  Future<String> getToken() async {
    String? token = sharedPreferences.getString(_keyToken);
    return token ?? '';
  }

  @override
  Future<void> clearCache() async {
    await sharedPreferences.remove(CACHED_BOOKMARKED_ARTICLES);
    await sharedPreferences.remove(_keyToken);
    await sharedPreferences.remove(CACHED_USER_DATA);
  }

  @override
  Future<void> cacheUserData(UserDataModel user) {
    final userDataJson = jsonEncode(user.toJson());
    return sharedPreferences.setString(CACHED_USER_DATA, userDataJson);
  }

  @override
  Future<UserDataModel> getUserData() async {
    final userDataJson = sharedPreferences.getString(CACHED_USER_DATA);

    if (userDataJson != null) {
      final userDataMap = jsonDecode(userDataJson);
      return UserDataModel.fromJson(userDataMap);
    } else {
      throw const CacheException(message: 'No cached user data found');
    }
  }
}
