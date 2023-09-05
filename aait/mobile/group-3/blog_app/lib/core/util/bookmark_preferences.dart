import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

import '../../features/article/domain/entity/article.dart';
import '../../features/article/domain/use_case/get_article_by_id.dart';
import '../error/exception.dart';
import 'constants.dart';

Future<String> getArticleById(String id) async {
  String baseUrl = getBaseUrl();
    try {
      String token = await getStoredToken();

      var request = http.Request('GET', Uri.parse('$baseUrl/article/$id'));
      request.headers['Authorization'] = 'Bearer $token';

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        final http.Response result = await http.Response.fromStream(response);

        final jsonResponse = jsonDecode(result.body);
        return jsonEncode(jsonResponse["data"]);

      } else {
        final result = await http.Response.fromStream(response);
        throw ServerException(
            statusCode: result.statusCode,
            message: "Failed to get the article");
      }
    } catch (e) {
      throw ServerException(
          statusCode: 500, message: "Failed to get the article$e");
    }
  }

  Future<String> getStoredToken() async {
    final SharedPreferences pref = await SharedPreferences.getInstance();
    final String token = pref.getString(cachedToken)!;
    return token;
  }

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

  static Future<String> getAllBookmarked(String userId)async {
    final articleIds = _preferences?.getStringList(userId) ?? [];
    List<String> articles = [];

    for (String id in articleIds) {
      final article = await getArticleById(id);
      final articleMap = jsonDecode(article);
      if (articleMap != null)
      articles.add(article);
    }
    final finalResult = jsonEncode(articles);
    print("===============I accomplished my mission===============");
    print(finalResult);
    return finalResult;
  }
}
