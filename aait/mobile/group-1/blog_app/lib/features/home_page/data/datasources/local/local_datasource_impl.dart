import 'dart:convert';

import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../models/article_model.dart';
import '../../models/tag_model.dart';
import 'local_datasource.dart';

class ArticleLocalDataSourceImpl extends ArticleLocalDataSource {
  final articleKey = 'CACHED_ARTICLES';
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

    throw CacheException();
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
}
