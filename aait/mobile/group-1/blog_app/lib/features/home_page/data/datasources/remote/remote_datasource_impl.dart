import 'dart:convert';

import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:http/http.dart';
import 'package:http/http.dart' as http;

import '../../../domain/entities/tag.dart';
import '../../models/article_model.dart';
import '../../models/tag_model.dart';
import 'remote_datasource.dart';

class ArticleRemoteDataSourceImpl extends ArticleRemoteDataSource {
  final http.Client client;

  ArticleRemoteDataSourceImpl({required this.client});

  @override
  Future<List<ArticleModel>> getAllArticles() async {
    try {
      final response = await client.get(
          Uri.parse("https://blog-api-4z3m.onrender.com/api/v1/article"),
          headers: {'Content-Type': 'application/json'});
      print(response.body);

      if (response.statusCode == 200) {
        print("succedded");
        try {
          final decoded = jsonDecode(response.body)['data'];
          print("decodded");
          print(decoded);

          final articleModel = decoded
              .map<ArticleModel>((e) => ArticleModel.fromJson(e))
              .toList();
          print(articleModel);
          return articleModel;
        } on FormatException {
          throw ServerException();
        }
      } else {
        throw ServerException();
      }
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<List<ArticleModel>> filterArticles(Tag tag, String title) async {
    try {
      final response = await client.get(Uri.parse(
          "http://localhost:4500/api/v1/article?tags=$tag&searchParams=$title"));

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = decoded
              .map<ArticleModel>((e) => ArticleModel.fromJson(e))
              .toList();

          return articleModel;
        } on FormatException {
          throw ServerException();
        }
      } else {
        throw ServerException();
      }
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<ArticleModel> getArticle(
    String id,
  ) async {
    try {
      final response = await client.get(
          Uri.parse("https://blog-api-4z3m.onrender.com/api/v1/article/$id"),
          headers: {'Content-Type': 'application/json'});

      if (response.statusCode == 200) {
        try {
          final decoded = jsonDecode(response.body)['data'];

          final articleModel = ArticleModel.fromJson(decoded);

          return articleModel;
        } on FormatException {
          throw ServerException();
        }
      } else {
        throw ServerException();
      }
    } catch (e) {
      throw ServerException();
    }
  }

  @override
  Future<List<TagModel>> getTags() async {
    final response = await client.get(
        Uri.parse("http://localhost:4500/api/v1/tags"),
        headers: {'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      try {
        final decoded = jsonDecode(response.body)['tags'];

        final tagModel = decoded
            .map<TagModel>((tagName) => TagModel(name: tagName))
            .toList();

        return tagModel;
      } on FormatException {
        throw ServerException();
      }
    } else {
      throw ServerException();
    }
  }
}
