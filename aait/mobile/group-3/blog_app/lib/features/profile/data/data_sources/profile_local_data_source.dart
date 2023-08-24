import 'dart:convert';

import 'package:blog_app/features/profile/data/models/article_model.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:shared_preferences/shared_preferences.dart';

abstract class ProfileLocalDataSource {
  Future<List<Article>> getBookmarkArticles();
}

const CACHED_ARTICLE_LIST = 'CACHED_ARTICLE_LIST';

class ProfileLocalDataSourceImpl implements ProfileLocalDataSource {
  final SharedPreferences sharedPreferences;

  ProfileLocalDataSourceImpl({required this.sharedPreferences});

  @override
  Future<List<Article>> getBookmarkArticles() async {
    final jsonValues = await sharedPreferences.getString(CACHED_ARTICLE_LIST);
    if (jsonValues != null) {
      final Map<String, dynamic> jsonList = jsonDecode(jsonValues);
      final List<Article> convertedList =
          jsonList["articles"].map<Article>((e) => ArticleModel.fromJson(
          e)).toList();
      return Future.value(convertedList);
    }else{
      return Future.value(<ArticleModel>[]);
    }
  }
}
