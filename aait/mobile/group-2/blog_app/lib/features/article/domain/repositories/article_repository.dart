import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../entities/article.dart';

abstract class ArticleRepository {
  Stream<Either<Failure, List<Article>>> getAllArticles();
  Stream<Either<Failure, Article>> createArticle(Article article);
  Stream<Either<Failure, Article>> getArticle(Article article);
  Stream<Either<Failure, Article>> updateArticle(Article article);
  Stream<Either<Failure, Article>> deleteArticle(Article article);
}