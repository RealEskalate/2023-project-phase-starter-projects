import 'dart:async';
import '../../../../article/data/models/article_model.dart';

abstract class UserLocalDataSource {
  Future<void> cacheBookmarkedArticles(List<ArticleModel> articlesToCache);
  Future<List<ArticleModel>> getAllBookmarkedArticles();
  Future<void> removeBookmark(String userArticleId);

  Future<void> cacheToken(String token);
  Future<String> getToken();
  Future<void> clearToken();
}
