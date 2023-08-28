import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/core/network/network_info.dart';
import 'package:blog_app/features/blog/data/datasources/remote_remote_data_source.dart';
import 'package:blog_app/features/blog/data/models/create_article_model.dart';
import 'package:blog_app/features/blog/domain/entities/article_enitity.dart';
import 'package:blog_app/features/blog/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';

import '../../domain/entities/create_article_entity.dart';

class ArticleRepositoryImpl extends ArticleRepository {
  final NetworkInfo networkInfo;
  final ArticleRemoteDataSource remoteDataSource;

  ArticleRepositoryImpl(
      {required this.networkInfo, required this.remoteDataSource});

  @override
  Future<Either<Failure, Article>> createArticle(
      CreateArticleEntity article) async {
    CreateArticleModel createArticleModel = CreateArticleModel(
        title: article.title,
        subTitle: article.subTitle,
        tags: article.tags,
        content: article.content);
    final isConnected = await networkInfo.isConnected;
    if (isConnected) {
      final article = await remoteDataSource.postArticle(createArticleModel);
      return Right(article);
    } else {
      return Left(ConnectionFailure(message: "Failed to connect to the ethernet"));
    }
  }

  @override
  Future<Either<Failure, Article>> updateArticle(
      CreateArticleEntity article) async {
    CreateArticleModel createArticleModel = CreateArticleModel(
        title: article.title,
        subTitle: article.subTitle,
        tags: article.tags,
        content: article.content);
    final isConnected = await networkInfo.isConnected;
    if (isConnected) {
      final article = await remoteDataSource.updateArticle(createArticleModel);
      return Right(article);
    } else {
      return Left(
          ConnectionFailure(message: "Failed to connect to the ethernet"));
    }
  }
}
