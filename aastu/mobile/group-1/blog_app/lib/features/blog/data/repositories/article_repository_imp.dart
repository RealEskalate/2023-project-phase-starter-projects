import 'dart:developer';

import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/blog/data/datasources/data_source_api.dart';
import 'package:blog_app/features/blog/data/models/blog_model.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';

class ArticleRepositoryImpl implements ArticleRepository {
  final BlogRemoteDataSource remoteDataSource;

  ArticleRepositoryImpl({required this.remoteDataSource});

  @override
  Future<Either<Failure, List<Article>>> getAllArticles() async {
    try {
      final articles = await remoteDataSource.getAllBlog();

      return Right(articles);
    } catch (e) {
      log("Error fetching articles-: $e");
      return const Left(ServerFailure('Error fetching articles'));
    }
  }

  @override
  Future<Either<Failure, List<Article>>> searchArticle(
      String tag, String key) async {
    try {
      final articles = await remoteDataSource.searchArticle(tag, key);
      return Right(articles);
    } catch (e) {
      log("Error searching articles: $e");
      return const Left(ServerFailure('Error searching articles'));
    }
  }

  @override
  Future<Either<Failure, Article>> createArticle(Article newArticle) async {
    try {
      Map<String, dynamic> articleData = {
        'title': newArticle.title,
        'content': newArticle.content,
        'subTitle': newArticle.subTitle,
        // 'tagList': newArticle.tagList,
      };
      final responseData = await remoteDataSource.postBlog(articleData);
      if (responseData != null) {
        final article = Article.fromJson(responseData);
        // Save user data to local storage
        // await localDataSource.saveUserData(user);

        return Right(article);
      } else {
        log("Invalid response data format: $responseData");
        return const Left(ServerFailure('Invalid response data format'));
      }
    } catch (e) {
      return const Left(ServerFailure('Error registering user'));
    }
    // TODO: implement createArticle
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, void>> deleteArticle(String articleId) {
    // TODO: implement deleteArticle
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, Article>> getAllArticle(String tags) {
    // TODO: implement getAllArticle
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, Article>> getSingleArticle(String articleId) {
    // TODO: implement getSingleArticle
    throw UnimplementedError();
  }

  @override
  Future<List<String>> getTags() {
    // TODO: implement getTags
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, void>> updateArticle(Article article) {
    // TODO: implement updateArticle
    throw UnimplementedError();
  }
}
