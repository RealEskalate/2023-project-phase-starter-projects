
import 'package:shared_preferences/shared_preferences.dart';

import '../../features/article/domain/entity/article.dart';
import '../../features/article/domain/use_case/get_article_by_id.dart';

class BookmarkPreferences {
  static SharedPreferences? _preferences;
  static GetArticleByIdUsecase? usecase;

  static Future init() async =>
      _preferences = await SharedPreferences.getInstance();

  static Future setBookmartk(String userId, String articleId) async {
    final bookmarkedArticles = _preferences?.getStringList(userId);
    if (bookmarkedArticles == null){
      await _preferences?.setStringList(userId, [articleId]);
      return true;
    } else if(bookmarkedArticles.contains(articleId)){
      bookmarkedArticles.remove(articleId);
      await _preferences?.setStringList(userId, bookmarkedArticles);
      return false;
    } else {
      bookmarkedArticles.add(articleId);
      await _preferences?.setStringList(userId, bookmarkedArticles);
      return true;
    }

  }
  
  static bool isBookmarked(String userId, String articleId) {
    final bookmarkedArticles = _preferences?.getStringList(userId);
    return bookmarkedArticles!= null && bookmarkedArticles.contains(articleId);
  }

  static List<String> getAllBookmarkedIds(String userId) {
    return _preferences?.getStringList(userId) ?? [];
  }

  static Future<List<Article>> getAllBookmarkedModels(String userId)async {
    final articleIds = _preferences?.getStringList(userId) ?? [];
    List<Article> articles = [];

    for (String id in articleIds) {
      final article = await usecase!(id);
      article.fold((l) => null, (value) => articles.add(value));
    }

    return articles;
  }
}
