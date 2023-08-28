import 'dart:convert';
import 'dart:developer';

import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/blog/data/datasources/data_source_api.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;

class RemoteDataSource implements BlogRemoteDataSource {
  final String baseUrl;

  RemoteDataSource({required this.baseUrl});

  Future<dynamic> _fetchData(String endpoint, Map<String, dynamic> blogData,
      [bool isGetReq = false]) async {
    log("fetching: $baseUrl/$endpoint");
    try {
      var response;
      if (isGetReq) {
        response = await http.get(
          Uri.parse('$baseUrl/$endpoint'),
          headers: {'Content-Type': 'application/json'},
        );
      } else {
        response = await http.post(
          Uri.parse('$baseUrl/$endpoint'),
          headers: {'Content-Type': 'application/json'},
        );
      }

      final responseData = json.decode(response.body);

      if (response.statusCode == 200 && responseData['success'] == true) {
        log("fetched: $responseData");
        return responseData['data'];
      } else {
        log("error: $responseData");
        final errorMessage =
            responseData['message'] as String? ?? 'Unknown error';
        throw Exception(errorMessage);
      }
    } catch (e) {
      log("error:: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<List<Article>> getAllBlog() async {
    final responseData = await _fetchData('article', {});

    List<Article> articles = [];
    try {
      for (var blogData in responseData) {
        log(blogData.toString());
        articles.add(Article.fromJson(blogData));
        log("Check 2");
      }
      return articles;
    } catch (e) {
      log("Error fetching articles: $e");
      throw Exception('An error occurred: $e');
    }
  }

  @override
  Future<Map<String, dynamic>> postBlog(Map<String, dynamic> blogData) async {
    return await _fetchData('article', blogData);

    // TODO: implement postBlog
    // throw UnimplementedError();
  }

  @override
  Future<void> deleteBlog(String articleId) {
    // TODO: implement deleteBlog
    throw UnimplementedError();
  }

  @override
  Future<List<Article>> searchArticle(String tag, String key) async {
    try {
      final endpoint = 'article?tags=$tag&searchParams=$key';
      final response = await _fetchData(endpoint, {});

      List<Article> articles = [];
      for (var articleData in response) {
        articles.add(Article.fromJson(articleData));
      }
      return articles;
    } catch (e) {
      log("Error fetching search articles: $e");
      throw Exception('An error occurred: $e');
    }
  }
}
