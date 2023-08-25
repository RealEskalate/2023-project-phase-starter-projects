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
    //for testing purpose
    final dummy = _getDummyArticles();
    final jsonVal = jsonEncode(dummy);
    sharedPreferences.setString(CACHED_ARTICLE_LIST, jsonVal);
    ///////////////////////////////////////////////////////////////////
    final jsonValues = await sharedPreferences.getString(CACHED_ARTICLE_LIST);
    if (jsonValues != null) {
      final List<dynamic> jsonList = jsonDecode(jsonValues);
      final List<Article> convertedList = jsonList.map<Article>((e) => ArticleModel.fromJson(e))
          .toList();
      return Future.value(convertedList);
    } else {
      return Future.value(<ArticleModel>[]);
    }
  }

  List<Map<String, dynamic>> _getDummyArticles() {
  final List<Map<String, dynamic>> _articles = [
    {
      "title": "GAME",
      "subTitle": "Why Elden Ring is the best game ever made",
      "createdAt": DateTime(2023, 8, 20).toIso8601String(),
      "id": "gashbvSAahnvbvsfw",
      "image": "https://www.techspot.com/images2/news/bigimage/2022/03/2022-03-17-image-37.jpg",
    },
    {
      "title": "SPACE",
      "subTitle": "How are galaxies constantly expanding",
      "createdAt": DateTime(2023, 8, 22, 12).toIso8601String(),
      "id": "bsdrnvjwnvwjsd",
      "image": "https://t4.ftcdn.net/jpg/05/51/96/35/360_F_551963598_53hrJ2UXDoC00XhkqJ8lKN8Xa2EQg4no.jpg",
    },
    {
      "title": "VALHEIM",
      "subTitle": "Valheim next biggest update is the ocean",
      "createdAt": DateTime(2023, 8, 22, 16).toIso8601String(),
      "id": "bsdrnvfdsfgdgfgfdd",
      "image": "https://i.etsystatic.com/24434904/r/il/b2ba6a/4092042802/il_fullxfull.4092042802_q13p.jpg",
    },
    {
      "title": "VALHEIM",
      "subTitle": "Valheim next biggest update is the ocean",
      "createdAt": DateTime(2023, 8, 22, 16).toIso8601String(),
      "id": "bsdrnvfdsfgdgfgfdd",
      "image": "https://i.etsystatic.com/24434904/r/il/b2ba6a/4092042802/il_fullxfull.4092042802_q13p.jpg",
    },
  ];
  return _articles;
}

}
