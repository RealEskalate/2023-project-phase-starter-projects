import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../../core/constants/constants.dart';
import '../../../../../core/error/exception.dart';
import '../../models/article_model.dart';
import 'remote_datasource.dart';

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  final http.Client client;

  ArticleRemoteDataSourceImpl({required this.client});

  @override
  Future<ArticleModel> createArticle(ArticleModel article) async {
    try {
      final response = await client.post(Uri.parse(apiBaseUrl),
          headers: {'Content-Type': 'application/json'},
          body: jsonEncode(article.toJson()));

      if (response.statusCode == 201) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = ArticleModel.fromJson(decoded);
          return articleModel;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }

  @override
  Future<ArticleModel> deleteArticle(String id) async {
    try {
      final response = await client.delete(Uri.parse('$apiBaseUrl$id'),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = ArticleModel.fromJson(decoded);

          return articleModel;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }

  @override
  Future<List<ArticleModel>> getAllArticles() async {
    try {
      final response = await client.get(Uri.parse(apiBaseUrl),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = decoded
              .map<ArticleModel>((e) => ArticleModel.fromJson(e))
              .toList();

          return articleModel;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }

  @override
  Future<ArticleModel> getArticle(String id) async {
    try {
      final response = await client.get(Uri.parse(apiBaseUrl),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = ArticleModel.fromJson(decoded);

          return articleModel;
        } on FormatException {
          throw const ServerException(message: 'Invalid Response');
        }
      } else {
        throw const ServerException(message: 'Operation Failed');
      }
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }

  @override
  Future<ArticleModel> updateArticle(ArticleModel article) async {
    try {
      final response = await client.put(Uri.parse('$apiBaseUrl${article.id}'),
          headers: {'Content-Type': 'application/json'},
          body: jsonEncode(article.toJson()));

      if (response.statusCode != 201) {
        throw const ServerException(message: 'Operation Failed');
      }
      return article;
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }
}
