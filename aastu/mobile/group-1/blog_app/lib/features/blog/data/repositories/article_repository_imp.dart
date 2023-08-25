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
  Future<Either<Failure, void>> createArticle(Article article) {
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
