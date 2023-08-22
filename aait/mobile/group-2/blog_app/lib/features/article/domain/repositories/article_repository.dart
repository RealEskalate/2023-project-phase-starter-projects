import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Either<Failure, List<Article>>> getAllArticles();
  Future<Either<Failure, Article>> createArticle(Article article);
  Future<Either<Failure, Article>> getArticle(Article article);
  Future<Either<Failure, Article>> updateArticle(Article article);
  Future<Either<Failure, Article>> deleteArticle(Article article);
}