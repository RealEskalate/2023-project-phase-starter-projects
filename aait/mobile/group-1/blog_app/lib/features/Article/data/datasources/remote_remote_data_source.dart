import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import '../../../../core/utils/constants.dart';
import '../models/article_model.dart';
import '../models/create_article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> postArticle(CreateArticleModel articleModel);
  Future<ArticleModel> updateArticle(CreateArticleModel articleModel);
  Future<ArticleModel> getArticle(String id);
}

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  @override
  Future<ArticleModel> postArticle(CreateArticleModel articleModel) async {
    String? token = await getToken();
    token =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZWNmMzgzODk5NDQ1M2ZhMzkxZTIxMSIsImlhdCI6MTY5MzI1MDQ1MiwiZXhwIjoxNjk1ODQyNDUyfQ.ZgYBMdKyBgVLIxFnZ7CX5Rrg4jVIjj6fG6O_SoWhwk0";
    final response = await http.post(Uri.parse('$baseApi/article'),
        headers: {'Content-Type': 'application/json', "token": token!},
        body: json.encode(articleModel.toJson()));

    return ArticleModel.fromJson(jsonDecode(response.body));
  }

  @override
  Future<ArticleModel> updateArticle(CreateArticleModel articleModel) async {
    final String? token = await getToken();
    final id = articleModel.id;
    final response = await http.post(Uri.parse('$baseApi/article/$id'),
        headers: {'Content-Type': 'application/json', "token": token!},
        body: json.encode(articleModel.toJson()));

    return ArticleModel.fromJson(jsonDecode(response.body));
  }

  @override
  Future<ArticleModel> getArticle(String id) async {
    final String? token = await getToken();
    final response = await http.get(Uri.parse('$baseApi/article/$id'),
        headers: {'Content-Type': 'application/json', "token": token!});

    return ArticleModel.fromJson(jsonDecode(response.body));
  }

  Future<String?> getToken() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString('token');
  }
}
