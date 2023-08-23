import 'package:dartz/dartz.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failure.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/article.dart';
import '../../domain/repositories/article_repository.dart';
import '../datasources/local/local_datasource.dart';
import '../datasources/remote/remote_datasource.dart';
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
  Future<Either<Failure, Article>> createArticle(Article article) async {
    if (await networkInfo.isConnected) {
      try {
        final createdArticle =
            await remoteDataSource.createArticle(article as ArticleModel);
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
            await remoteDataSource.updateArticle(article as ArticleModel);

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
}
