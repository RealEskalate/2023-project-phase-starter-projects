import 'package:dartz/dartz.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failure.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/article.dart';
import '../../domain/entities/tag.dart';
import '../../domain/repositories/article_repository.dart';
import '../datasources/local/local_datasource.dart';
import '../datasources/remote/remote_datasource.dart';
import '../models/article_mapper.dart';

class ArticleRepositoryImpl extends ArticleRepository {
  final ArticleLocalDataSource localDataSource;
  final ArticleRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  ArticleRepositoryImpl(
      {required this.localDataSource,
      required this.remoteDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, Article>> createArticle(Article article) async {
    if (await networkInfo.isConnected) {
      try {
        final createdArticle =
            await remoteDataSource.createArticle(article.toArticleModel());

        return Right(createdArticle);
      } on ServerException {
        return Left(ServerFailure());
      } on NetworkException {
        return Left(NetworkFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

  @override
  Future<Either<Failure, Article>> deleteArticle(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final deletedArticle = await remoteDataSource.deleteArticle(id);
        await localDataSource.deleteArticle(id);
        return Right(deletedArticle);
      } on ServerException {
        return Left(ServerFailure());
      } on NetworkException {
        return Left(NetworkFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

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
          return Left(CacheFailure());
        }
      }
    } else {
      try {
        final article = await localDataSource.getArticle(id);
        return Right(article);
      } catch (e) {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, Article>> updateArticle(Article article) async {
    if (await networkInfo.isConnected) {
      try {
        final updatedArticle =
            await remoteDataSource.updateArticle(article.toArticleModel());

        await localDataSource.cacheArticle(updatedArticle);

        return Right(updatedArticle);
      } on ServerException {
        return Left(ServerFailure());
      } on NetworkException {
        return Left(NetworkFailure());
      }
    } else {
      return Left(NetworkFailure());
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

  @override
  Future<Either<Failure, List<Article>>> getBookmarkedArticles() async {
    final articles = await localDataSource.getBookmarkedArticles();
    return Right(articles);
  }

  @override
  Future<Either<Failure, Article>> addToBookmark(Article article) async {
    await localDataSource.addToBookmark(article.toArticleModel());
    return Right(article);
  }

  @override
  Future<Either<Failure, Article>> removeFromBookmark(String articleId) async {
    final article = await localDataSource.removeFromBookmark(articleId);
    return Right(article);
  }
}
