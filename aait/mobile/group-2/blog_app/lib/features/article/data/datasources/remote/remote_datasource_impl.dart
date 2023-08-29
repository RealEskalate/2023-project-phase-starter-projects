import 'dart:convert';

import 'package:http/http.dart';

import '../../../../../core/error/exception.dart';
import '../../../../../core/network/custom_client.dart';
import '../../../domain/entities/tag.dart';
import '../../models/article_model.dart';
import '../../models/dto/create_article_dto.dart';
import '../../models/tag_model.dart';
import 'remote_datasource.dart';

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  final CustomClient client;

  ArticleRemoteDataSourceImpl({required this.client});

  @override
  Future<ArticleModel> createArticle(ArticleModel article) async {
    final dto = CreateUpdateArticleDto(
      title: article.title,
      subTitle: article.subTitle,
      estimatedReadTime: article.estimatedReadTime,
      photoPath: article.photoUrl,
      tags: article.tags.map<String>((e) => e.name).toList(),
      content: article.content,
    );

    StreamedResponse response;

    try {
      response = await client.multipartRequest(
        'article/',
        method: 'POST',
        body: dto.toJson(),
      );
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }

    if (response.statusCode == 200) {
      try {
        final data = await response.stream.bytesToString();

        final decoded = jsonDecode(data)['data'];

        final articleModel = ArticleModel.fromJson(decoded);
        return articleModel;
      } on FormatException {
        throw const ServerException(message: 'Invalid Response');
      }
    } else {
      throw const ServerException(message: 'Operation Failed');
    }
  }

  @override
  Future<ArticleModel> deleteArticle(String id) async {
    try {
      final response = await client.delete('article/$id');

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['date'];
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
      final response = await client.get('article/');

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
  Future<List<ArticleModel>> filterArticles(Tag tag, String title) async {
    try {
      final response = await client.get('article/',
          queryParams: {'tags': tag.name, 'searchParams': title});

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
      final response = await client.get('article/$id');

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
    final dto = CreateUpdateArticleDto(
      title: article.title,
      subTitle: article.subTitle,
      estimatedReadTime: article.estimatedReadTime,
      photoPath: article.photoUrl,
      tags: article.tags.map<String>((e) => e.name).toList(),
      content: article.content,
    );

    StreamedResponse response;

    try {
      response = await client.multipartRequest(
        'article/${article.id}',
        method: 'PUT',
        body: dto.toJson(),
      );
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }

    if (response.statusCode == 200) {
      try {
        final data = await response.stream.bytesToString();

        final decoded = jsonDecode(data)['data'];

        final articleModel = ArticleModel.fromJson(decoded);
        return articleModel;
      } on FormatException {
        throw const ServerException(message: 'Invalid Response');
      }
    } else {
      throw const ServerException(message: 'Operation Failed');
    }
  }

  @override
  Future<List<TagModel>> getTags() async {
    Response response;

    try {
      response = await client.get('tags/');
    } catch (e) {
      throw const ServerException(message: 'Connection Failed');
    }

    if (response.statusCode == 200) {
      try {
        final decoded = jsonDecode(response.body)['tags'];

        final tagModel = decoded
            .map<TagModel>((tagName) => TagModel(name: tagName))
            .toList();

        return tagModel;
      } on FormatException {
        throw const ServerException(message: 'Invalid Response');
      }
    } else {
      throw const ServerException(message: 'Operation Failed');
    }
  }
}
