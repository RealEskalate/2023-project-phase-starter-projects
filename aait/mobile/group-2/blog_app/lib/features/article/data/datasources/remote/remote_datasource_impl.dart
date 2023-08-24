import 'dart:convert';

import '../../../../../core/error/exception.dart';
import '../../../../../core/network/custom_client.dart';
import '../../models/article_model.dart';
import 'remote_datasource.dart';

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  final CustomClient client;

  ArticleRemoteDataSourceImpl({required this.client});

  @override
  Future<ArticleModel> createArticle(ArticleModel article) async {
    try {
      final response = await client.post('/', body: article.toJson());

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
      final response = await client.delete('/$id');

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
      final response = await client.get('/');

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
  Future<ArticleModel> getArticle(
    String id,
  ) async {
    try {
      final response = await client.get('/$id');

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
      final response =
          await client.put('/${article.id}', body: article.toJson());

      if (response.statusCode != 201) {
        throw const ServerException(message: 'Operation Failed');
      }
      return article;
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }
  }
}
