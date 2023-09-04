import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';
import 'package:mime/mime.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/util/convert_to_png.dart';
import '../../domain/entity/getArticlesEntity.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/util/constants.dart';
import '../models/article_model.dart';
import '../models/user_model.dart';

abstract class ArticleRemoteDataSource {
  Future<ArticleModel> createArticle(ArticleModel article);
  Future<ArticleModel> updateArticle(ArticleModel article);
  Future<void> deleteArticle(String id);
  Future<List<ArticleModel>> getArticle(String tags, String searchParams);
  Future<ArticleModel> getArticleById(String id);
  Future<List<ArticleModel>> getAllArticles(ArticleRequest articleRequest);
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
    String token = await getStoredToken();
    try {
      var photoFile = File(article.image);
      var mimeType = lookupMimeType(photoFile.path)!;
      if (mimeType != "image/png" || mimeType != "image/jpeg") {
        final pngImage = convertToPng(photoFile);
        photoFile = pngImage;
        mimeType = lookupMimeType(photoFile.path)!;
      }

      var request =
          http.MultipartRequest('POST', Uri.parse('$baseUrl/article'));

      request.headers['Authorization'] = 'Bearer $token';

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
    } catch (e) {
      throw ServerException(
          statusCode: 404, message: "Failed to Create an article!$e");
    }
  }

  @override
  Future<void> deleteArticle(String id) async {
    try {
      String token = await getStoredToken();
      var request = http.Request('DELETE', Uri.parse('$baseUrl/article/$id'));
      request.headers['Authorization'] = "Bearer $token";

      http.StreamedResponse response = await request.send();

      if (response.statusCode != 200) {
        final result = await http.Response.fromStream(response);
        throw ServerException(
            statusCode: result.statusCode,
            message: "Failed to delete an article!");
      }
    } catch (e) {
      throw ServerException(
          statusCode: 404, message: "Failed to delete an article!$e");
    }
  }

  @override
  Future<List<ArticleModel>> getAllArticles(
      ArticleRequest articleRequest) async {
    try {
      String tags = "";
      for (int i = 0; i < articleRequest.tags.length; i++) {
        tags += articleRequest.tags[i] + ",";
      }
      final response = await client.get(
        Uri.parse(
            'https://blog-api-4z3m.onrender.com/api/v1/article?searchParams=${articleRequest.queryString}&tags=${tags}'),
        headers: {"Content-Type": 'application/json'},
      );
      if (response.statusCode == 200) {
        print("object found");
        print(response.body);
        print("object found");
        List<dynamic> jsonResponse = jsonDecode(response.body)["data"];
        List<ArticleModel> result = jsonResponse
            .map((articleData) => ArticleModel.fromJson(articleData))
            .toList();
        return result;
      } else {
        throw ServerException(
            statusCode: 500, message: "Failed to fetch articles");
      }
    } catch (e) {
      throw ServerException(
          statusCode: 500, message: "Failed to fetch articles$e");
    }
  }

  @override
  Future<List<ArticleModel>> getArticle(
      String tags, String searchParams) async {
    try {
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
    } catch (e) {
      throw ServerException(
          statusCode: 500, message: "Failed to fetch articles$e");
    }
  }

  @override
  Future<ArticleModel> getArticleById(String id) async {
    try {
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
            statusCode: result.statusCode,
            message: "Failed to get the article");
      }
    } catch (e) {
      throw ServerException(
          statusCode: 500, message: "Failed to get the article$e");
    }
  }

  @override
  Future<List<String>> getTags() async {
    try {
      String token = await getStoredToken();
      var request = http.Request('GET', Uri.parse('$baseUrl/tags'));
      request.headers['Authorization'] = 'Bearer $token';

      http.StreamedResponse response = await request.send();

      if (response.statusCode == 200) {
        final http.Response result = await http.Response.fromStream(response);
        final jsonResponse = jsonDecode(result.body);
        final tags = jsonResponse['tags'];
        return List<String>.from(tags)
            .map((tagData) => tagData.toString())
            .toList();
      } else {
        throw ServerException(
            message: "Failed to fetch tags", statusCode: response.statusCode);
      }
    } catch (e) {
      throw ServerException(message: "Failed to fetch tags$e", statusCode: 500);
    }
  }

  @override
  Future<ArticleModel> updateArticle(ArticleModel article) async {
    try {
      String token = await getStoredToken();
      final String id = article.id;
      var request =
          http.MultipartRequest('PUT', Uri.parse('$baseUrl/article/$id'));
      request.headers['Authorization'] = 'Bearer $token';
      var photoFile = File(article.image);
      var mimeType = lookupMimeType(photoFile.path)!;
      if (mimeType != "image/png" && mimeType != "image/jpeg") {
        final pngImage = convertToPng(photoFile);
        photoFile = pngImage;
        mimeType = lookupMimeType(photoFile.path)!;
      }
      request.files.add(await http.MultipartFile.fromPath(
        'photo',
        article.image,
        filename: photoFile.path.split('/').last, // Extract the filename
        contentType: MediaType.parse(mimeType),
      ));

      for (int i = 0; i < article.tags.length; i++) {
        request.fields['tags[$i]'] = article.tags[i];
      }
      request.fields.addAll({
        'content': article.content,
        'title': article.title,
        'subTitle': article.subTitle,
        'estimatedReadTime': article.estimatedReadTime,
      });

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
    } catch (e) {
      throw ServerException(
          statusCode: 500, message: "Failed to Update an article!$e");
    }
  }

  @override
  Future<UserModel> getUser() async {
    try {
      String token = await getStoredToken();
      final result = await client.get(Uri.parse('$baseUrl/user'),
          headers: {"Authorization": "Bearer $token"});

      if (result.statusCode == 200) {
        final jsonResponse = jsonDecode(result.body);
        final UserModel user = UserModel.fromJson(jsonResponse);
        return user;
      } else {
        throw ServerException(
            message: "Failed to fetch user data!",
            statusCode: result.statusCode);
      }
    } catch (e) {
      throw ServerException(
          message: "Failed to fetch user data$e", statusCode: 500);
    }
  }

  Future<String> getStoredToken() async {
    final SharedPreferences pref = await SharedPreferences.getInstance();
    final String token = pref.getString(cachedToken)!;
    return token;
  }
}
