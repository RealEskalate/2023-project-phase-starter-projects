import 'package:blog_app/core/error/failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Either<Failure, List<Article>>> getAllArticles();
  Future<Either<Failure, Article>> getSingleArticle(String articleId);
  Future<Either<Failure, List<Article>>> searchArticle(String tag, String key);

  Future<Either<Failure, void>> updateArticle(Article article);
  Future<Either<Failure, void>> createArticle(Article article);
  Future<Either<Failure, void>> deleteArticle(String articleId);
  Future<List<String>> getTags();
}
