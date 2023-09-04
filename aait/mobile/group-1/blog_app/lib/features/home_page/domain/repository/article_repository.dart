import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/article.dart';
import '../entities/tag.dart';


abstract class ArticleRepository {
  Future<Either<Failure, List<Article>>> getAllArticles();
  Future<Either<Failure, List<Tag>>> getTags();
  Future<Either<Failure, Article>> getArticle(String id);

  Future<Either<Failure, List<Article>>> filterArticles(Tag tag, String title);
}