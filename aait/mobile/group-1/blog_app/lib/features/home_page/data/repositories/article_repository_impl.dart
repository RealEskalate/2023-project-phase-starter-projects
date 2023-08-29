import 'package:blog_app/core/errors/failures/exception.dart';
import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/home_page/domain/repository/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';

import '../../../../core/network/network_info.dart';
import '../../domain/entities/article.dart';
import '../../domain/entities/tag.dart';
import '../datasources/local/local_datasource.dart';
import '../datasources/remote/remote_datasource.dart';
import '../models/article_mapper.dart';
import '../models/article_model.dart';

class ArticleRepositoryImpl extends ArticleRepository {
  final ArticleLocalDataSource localDataSource;
  final ArticleRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  ArticleRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, List<Article>>> getAllArticles() async {
    if (await networkInfo.isConnected) {
      try {
        final articles = await remoteDataSource.getAllArticles();
        await localDataSource.cacheArticles(articles);

        return Right(articles);
      } catch (e) {
        final articles = await localDataSource.getArticles();
        return Right(articles);
      }
    } else {
      final articles = await localDataSource.getArticles();
      return Right(articles);
    }
  }

  @override
  Future<Either<Failure, List<Article>>> filterArticles(
      Tag tag, String title) async {
    if (await networkInfo.isConnected) {
      try {
        final articles = await remoteDataSource.filterArticles(tag, title);

        return Right(articles);
      } catch (e) {
        final articles = await localDataSource.getArticles();
        return Right(articles);
      }
    } else {
      final articles = await localDataSource.getArticles();
      return Right(articles);
    }
  }

  @override
  Future<Either<Failure, Article>> getArticle(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final article = await remoteDataSource.getArticle(id);
        await localDataSource.cacheArticle(article);
        return Right(article);
      } catch (e) {
        try {
          final article = await localDataSource.getArticle(id);
          return Right(article);
        } catch (e) {
          return Left(CacheFailure(message: "Cache Failure"));
        }
      }
    } else {
      try {
        final article = await localDataSource.getArticle(id);
        return Right(article);
      } catch (e) {
        return Left(CacheFailure(message: "Cache Failure"));
      }
    }
  }

  @override
  Future<Either<Failure, List<Tag>>> getTags() async {
    if (await networkInfo.isConnected) {
      try {
        final tags = await remoteDataSource.getTags();
        await localDataSource.cacheTags(tags);
        return Right(tags);
      } catch (e) {
        final tags = await localDataSource.getTags();
        return Right(tags);
      }
    } else {
      final tags = await localDataSource.getTags();
      return Right(tags);
    }
  }
}
