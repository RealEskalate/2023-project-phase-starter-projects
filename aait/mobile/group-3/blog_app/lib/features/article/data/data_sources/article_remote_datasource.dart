import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';
import 'package:mime/mime.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/util/constants.dart';
import '../models/article_model.dart';
import '../models/user_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> createArticle(ArticleModel article);
  Future<ArticleModel> updateArticle(ArticleModel article);
  Future<ArticleModel> deleteArticle(String id);
  Future<List<ArticleModel>> getArticle(String tags, String searchParams);
  Future<ArticleModel> getArticleById(String id);
  Future<List<ArticleModel>> getAllArticles();
  Future<List<String>> getTags();
  Future<UserModel> getUser();
}

class ArticleRemoteDataSourceImpl implements ArticleRemoteDataSource {
  final http.Client client;
  final SharedPreferences sharedPreferences;
  ArticleRemoteDataSourceImpl({
    required this.client,
    required this.sharedPreferences,
  });

  final uriString = 'https://blog-api-4z3m.onrender.com';

  String baseUrl = getBaseUrl();

  @override
  Future<ArticleModel> createArticle(ArticleModel article) async {
    print("h1");
    String token = await getStoredToken();
    final photoFile = File(article.image);
    print("h2");
    final String mimeType = lookupMimeType(article.image)!;
    print("h3");

    var request = http.MultipartRequest('POST', Uri.parse('$baseUrl/article'));
    print("h4");

    //  final token =
    // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZTg0ZDg3YWMyNDQ1NjZjNzcyNjA1MCIsImlhdCI6MTY5Mjk3MjAzMiwiZXhwIjoxNjk1NTY0MDMyfQ.SgdYuy3wvMEsDFhL_vs-e77s2D7txtMGUw5ew2hD-jI";
    request.headers['Authorization'] = 'Bearer $token';
    print("h1");

    // Loop through the tags list and add a separate field for each tag
    for (int i = 0; i < article.tags.length; i++) {
      request.fields['tags[$i]'] = article.tags[i];
    }
    request.fields.addAll({
      'content': article.content,
      'title': article.title,
      'subTitle': article.subTitle,
      'estimatedReadTime': article.estimatedReadTime,
    });
    request.files.add(http.MultipartFile.fromBytes(
      'photo',
      photoFile.readAsBytesSync(),
      filename: photoFile.path,
      contentType: MediaType.parse(mimeType),
    ));

    http.StreamedResponse response = await request.send();
    print(response);

    if (response.statusCode == 200) {
      print("yes");
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      print(jsonResponse);
      final newArticle = await getArticleById(jsonResponse["data"]["id"]);
      return newArticle;
    } else {
      final result = await http.Response.fromStream(response);
      throw ServerException(
          statusCode: result.statusCode,
          message: "Failed to Create an article!");
    }
  }

  @override
  Future<ArticleModel> deleteArticle(String id) async {
    String token = await getStoredToken();
    var request = http.Request('DELETE', Uri.parse('$baseUrl/article/$id'));
    request.headers['Authorization'] = "Bearer $token";

    http.StreamedResponse response = await request.send();

    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      final newArticle = await getArticleById(jsonResponse["data"]["id"]);
      return newArticle;
    } else {
      final result = await http.Response.fromStream(response);
      throw ServerException(
          statusCode: result.statusCode,
          message: "Failed to delete an article!");
    }
  }

  @override
  Future<List<ArticleModel>> getAllArticles() async {
    String token = await getStoredToken();
    var request = http.Request('GET', Uri.parse('$baseUrl/article'));
    request.headers['Authorization'] = 'Bearer $token';
    http.StreamedResponse response = await request.send();
    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body)["data"];
      return List<Map<String, dynamic>>.from(jsonResponse)
          .map((articleData) => ArticleModel.fromJson(articleData))
          .toList();
    } else {
      final result = await http.Response.fromStream(response);
      throw ServerException(
          statusCode: result.statusCode, message: "Failed to fetch articles");
    }
  }

  @override
  Future<List<ArticleModel>> getArticle(
      String tags, String searchParams) async {
    String token = await getStoredToken();

    var request = http.Request('GET',
        Uri.parse('$baseUrl/article?tags=$tags&searchParams=$searchParams'));

    request.headers['Authorization'] = "Bearer $token";

    http.StreamedResponse response = await request.send();

    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body)["data"] as List;

      return List<Map<String, dynamic>>.from(jsonResponse)
          .map((articleData) => ArticleModel.fromJson(articleData))
          .toList();
    } else {
      final result = await http.Response.fromStream(response);
      print(jsonDecode(result.body));
      throw ServerException(
          statusCode: result.statusCode, message: "Failed to fetch articles");
    }
  }

  @override
  Future<ArticleModel> getArticleById(String id) async {
    String token = await getStoredToken();

    var request = http.Request('GET', Uri.parse('$baseUrl/article/$id'));
    request.headers['Authorization'] = 'Bearer $token';

    http.StreamedResponse response = await request.send();

    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      print(jsonResponse.toString());
      final article = ArticleModel.fromJson(jsonResponse["data"]);
      return article;
    } else {
      final result = await http.Response.fromStream(response);
      throw ServerException(
          statusCode: result.statusCode, message: "Failed to get the article");
    }
  }

  @override
  Future<List<String>> getTags() async {
    String token = await getStoredToken();
    var request = http.Request('GET', Uri.parse('$baseUrl/tags'));
    request.headers['Authorization'] = 'Bearer $token';

    http.StreamedResponse response = await request.send();

    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      final tags = jsonResponse['data'];

      return List<String>.from(tags)
          .map((tagData) => tagData.toString())
          .toList();
    } else {
      throw ServerException(
          message: "Failed to fetch tags", statusCode: response.statusCode);
    }
  }

  @override
  Future<ArticleModel> updateArticle(ArticleModel article) async {
    String token = await getStoredToken();
    final String id = article.id;
    final photoFile = File(article.image);
    final String mimeType = lookupMimeType(article.image)!;

    var request =
        http.MultipartRequest('PUT', Uri.parse('$baseUrl/article/$id'));
    request.headers['Authorization'] = 'Bearer $token';

    for (int i = 0; i < article.tags.length; i++) {
      request.fields['tags[$i]'] = article.tags[i];
    }
    request.fields.addAll({
      'content': article.content,
      'title': article.title,
      'subTitle': article.subTitle,
      'estimatedReadTime': article.estimatedReadTime,
    });
    request.files.add(http.MultipartFile.fromBytes(
      'photo',
      photoFile.readAsBytesSync(),
      filename: photoFile.path,
      contentType: MediaType.parse(mimeType),
    ));

    http.StreamedResponse response = await request.send();

    if (response.statusCode == 200) {
      final http.Response result = await http.Response.fromStream(response);
      final jsonResponse = jsonDecode(result.body);
      final newArticle = await getArticleById(jsonResponse["data"]["id"]);
      return newArticle;
    } else {
      final result = await http.Response.fromStream(response);
      throw ServerException(
          statusCode: result.statusCode,
          message: "Failed to Update an article!");
    }
  }

  @override
  Future<UserModel> getUser() async {
    String token = await getStoredToken();
    final result = await client.get(Uri.parse('$baseUrl/user'),
        headers: {"Authorization": "Bearer $token"});

    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body);
      final UserModel user = UserModel.fromJson(jsonResponse);
      return user;
    } else {
      throw ServerException(
          message: "Could not connect to the server",
          statusCode: result.statusCode);
    }
  }

  Future<String> getStoredToken() async {
    final SharedPreferences pref = await SharedPreferences.getInstance();
    final String token = pref.getString(cachedToken)!;
    return token;
  }
}
