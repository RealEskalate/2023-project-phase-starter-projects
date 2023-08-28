import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/util/constants.dart';
import '../models/article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> createArticle(ArticleModel article);
  Future<ArticleModel> updateArticle(ArticleModel article);
  Future<ArticleModel> deleteArticle(String id);
  Future<List<ArticleModel>> getArticle(String tags, String searchParams);
  Future<ArticleModel> getArticleById(String id);
  Future<List<ArticleModel>> getAllArticles();
  Future<List<String>> getTags();
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  final http.Client client;
  final SharedPreferences sharedPreferences;
  final http.MultipartRequest request;
  ArticleRemoteDataSourceImpl({
    required this.client,
    required this.sharedPreferences,
    required this.request,
  });

  final uriString = 'http://localhost:4500/api/v1';
  String baseUrl = getBaseUrl();

  @override
  Future<ArticleModel> createArticle(ArticleModel article) async {
    String token =
        jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";
    try {
      final responseArticle = await client.post(
        Uri.parse('$baseUrl/article'),
        body: jsonEncode(article.toMap()),
      );

      if (responseArticle.statusCode == 200) {
        final responseUser = await client.get(Uri.parse('$baseUrl/user'));
        if (responseUser.statusCode == 200) {
          final newArticle = jsonDecode(responseArticle.body)["data"];
          final author = jsonDecode(responseUser.body)["data"];
          newArticle['user'] = author;
          return ArticleModel.fromJson(newArticle);
        }
        return ArticleModel.fromJson(jsonDecode(responseArticle.body));
      } else {
        throw ServerException(
            message: "Failed to create an article",
            statusCode: responseArticle.statusCode);
      }
    } catch (e) {
      throw ServerException(
          message: "Faild to create the article: $e", statusCode: 400);
    }
  }

  @override
  Future<ArticleModel> deleteArticle(String id) async {
    String token =
        jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";
    try {
      final responseArticle =
          await client.delete(Uri.parse('$baseUrl/article/$id'));
      if (responseArticle.statusCode == 200) {
        final responseUser = await client.get(Uri.parse('$baseUrl/user'));
        if (responseUser.statusCode == 200) {
          final deletedArticle = jsonDecode(responseArticle.body)['data'];
          final author = jsonDecode(responseUser.body)["data"];
          deletedArticle['user'] = author;
          return ArticleModel.fromJson(deletedArticle);
        }
        return ArticleModel.fromJson(jsonDecode(responseArticle.body));
      } else {
        throw ServerException(
            message: "Failed to delete the article",
            statusCode: responseArticle.statusCode);
      }
    } catch (e) {
      throw ServerException(
          message: "Faild to delete the article: $e", statusCode: 400);
    }
  }

  @override
  Future<List<ArticleModel>> getAllArticles() async {
    String token =
        jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";
    try {
      final response = await client.get(Uri.parse('$baseUrl/article'));
      if (response.statusCode == 200) {
        final responseMap = jsonDecode(response.body) as Map<String, dynamic>;
        final responseData = responseMap["data"] as List;

        return List<Map<String, dynamic>>.from(responseData)
          .map((articleData) => ArticleModel.fromJson(articleData))
          .toList();
      } else {
        throw ServerException(statusCode: response.statusCode, message: "Failed to fetch articles");
      }
    } catch (e) {
      throw ServerException(
          message: "Failed to fetch articles: $e", statusCode: 400);
    }
  }

  @override
  Future<List<ArticleModel>> getArticle(String tags, String searchParams) async {
    String token = jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";

    try {
      final String url = '$baseUrl/article?tags=$tags&searchParams=$searchParams';
      final response = await client.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final responseMap = jsonDecode(response.body);
        final responseData = responseMap['data'] as List;

        return List<Map<String, dynamic>>.from(responseData)
          .map((articleData) => ArticleModel.fromJson(articleData))
          .toList();
      } else {
        throw ServerException(statusCode: response.statusCode, message: "Failed to fetch article");
      }
    } catch (e) {
      throw ServerException(statusCode: 400, message: "Failed to fetch article: $e");
    }
  }

  @override
  Future<ArticleModel> getArticleById(String id) async {
    final String token = jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";

    try {
      final response = await client.get(Uri.parse('$baseUrl/article/$id'));
      if (response.statusCode == 200) {
        final responseMap = jsonDecode(response.body) as Map<String, dynamic>;
        final responseData = responseMap["data"];

        return ArticleModel.fromJson(responseData);
      } else {
        throw ServerException(statusCode: response.statusCode, message: "Failed to fetch article");
      }
    } catch(e) {
      throw ServerException(message: "Failed to fetch article: $e", statusCode: 400);
    }
  }

  @override
  Future<List<String>> getTags() async {
    final response = await client.get(Uri.parse('$baseUrl/tags'));
    if (response.statusCode == 200 || response.statusCode == 201) {
      final responseMap = jsonDecode(response.body) as Map<String, dynamic>;
      final responseData = responseMap["tags"];
      return List<String>.from(responseData)
          .map((tagData) => tagData.toString())
          .toList();
    } else {
      throw ServerException(
          message: "Failed to fetch tags", statusCode: response.statusCode);
    }
  }

  @override
  Future<ArticleModel> updateArticle(ArticleModel article) async {
    final String id = article.id;
    String token =
        jsonDecode(sharedPreferences.getString(cachedToken)!);
    request.headers['Authorization'] = "Bearer $token";
    try {
      final responseArticle = await client.put(
        Uri.parse('$baseUrl/article/$id'),
        body: jsonEncode(article.toMap()),
      );

      if (responseArticle.statusCode == 200) {
        final responseUser = await client.get(Uri.parse('$baseUrl/user'));
        if (responseUser.statusCode == 200) {
          final updatedArticle = jsonDecode(responseArticle.body)["data"];
          final author = jsonDecode(responseUser.body)["data"];
          updatedArticle['user'] = author;
          return ArticleModel.fromJson(updatedArticle);
        }
        return ArticleModel.fromJson(jsonDecode(responseArticle.body));
      } else {
        throw ServerException(
            message: "Failed to updtate an article",
            statusCode: responseArticle.statusCode);
      }
    } catch (e) {
      throw ServerException(
          message: "Faild to updtate the article: $e", statusCode: 400);
    }
  }
}
