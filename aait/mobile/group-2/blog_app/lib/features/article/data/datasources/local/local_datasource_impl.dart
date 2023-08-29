import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';

import '../../../../../core/error/exception.dart';
import '../../models/article_model.dart';
import '../../models/tag_model.dart';
import 'local_datasource.dart';

class ArticleLocalDataSourceImpl extends ArticleLocalDataSource {
  final articleKey = 'CACHED_ARTICLES';
  final bookmarkKey = 'BOOKMARKS';
  final tagKey = 'CACHED_TAGS';

  final SharedPreferences sharedPreferences;

  ArticleLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<void> cacheArticles(List<ArticleModel> articles) async {
    final jsonEncoded = jsonEncode(articles);

    await sharedPreferences.setString(articleKey, jsonEncoded);
  }

  @override
  Future<void> cacheArticle(ArticleModel article) async {
    final articles = await getArticles();

    final articleIndex =
        articles.indexWhere((element) => element.id == article.id);

    // If article is not in the list, add it
    if (articleIndex == -1) {
      articles.add(article);
    }

    // If article is in the list, replace it
    else {
      articles[articleIndex] = article;
    }

    await cacheArticles(articles);
  }

  @override
  Future<List<ArticleModel>> getArticles() async {
    final jsonEncoded = sharedPreferences.getString(articleKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final articles = jsonDecoded
          .map<ArticleModel>((map) => ArticleModel.fromJson(map))
          .toList();

      return articles;
    }

    return <ArticleModel>[];
  }

  @override
  Future<ArticleModel> getArticle(String id) async {
    final articles = await getArticles();

    for (final article in articles) {
      if (article.id == id) {
        return article;
      }
    }

    throw const CacheException(message: '');
  }

  @override
  Future<void> deleteArticle(String id) async {
    final articles = await getArticles();

    final filteredArticles = articles.where((article) => article.id != id);

    await cacheArticles(filteredArticles.toList());
  }

  @override
  Future<List<TagModel>> getTags() async {
    final jsonEncoded = sharedPreferences.getString(tagKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);

      final tags =
          jsonDecoded.map<TagModel>((name) => TagModel(name: name)).toList();

      return tags;
    }

    return <TagModel>[];
  }

  @override
  Future<void> cacheTags(List<TagModel> tags) async {
    final jsonEncoded =
        jsonEncode(tags.map<String>((tag) => tag.name).toList());

    await sharedPreferences.setString(tagKey, jsonEncoded);
  }

  Future<void> _cacheBookmarks(List<ArticleModel> articles) async {
    final jsonEncoded = jsonEncode(articles);

    await sharedPreferences.setString(bookmarkKey, jsonEncoded);
  }

  @override
  Future<List<ArticleModel>> getBookmarkedArticles() async {
    final jsonEncoded = sharedPreferences.getString(bookmarkKey);

    if (jsonEncoded != null) {
      final List<dynamic> jsonDecoded = jsonDecode(jsonEncoded);
      final articles = jsonDecoded
          .map<ArticleModel>((map) => ArticleModel.fromJson(map))
          .toList();

      return articles;
    }

    return <ArticleModel>[];
  }

  @override
  Future<void> addToBookmark(ArticleModel article) async {
    final articles = await getBookmarkedArticles();

    final articleIndex =
        articles.indexWhere((element) => element.id == article.id);

    // If article is not in the list, add it
    if (articleIndex == -1) {
      articles.add(article);
    }

    // If article is in the list, replace it
    else {
      articles[articleIndex] = article;
    }

    await _cacheBookmarks(articles);
  }

  @override
  Future<ArticleModel> removeFromBookmark(String articleId) async {
    final articles = await getBookmarkedArticles();

    final filteredArticles =
        articles.where((article) => article.id != articleId);

    await _cacheBookmarks(filteredArticles.toList());

    return articles.firstWhere((article) => article.id == articleId);
  }
}
