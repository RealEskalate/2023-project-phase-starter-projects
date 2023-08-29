import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/article_enitity.dart';
import '../entities/create_article_entity.dart';

abstract class ArticleRepository {
  Future<Either<Failure, Article>> createArticle(CreateArticleEntity article);
  Future<Either<Failure, Article>> updateArticle(CreateArticleEntity article);
  Future<Either<Failure, Article>> getArticle(String id);
}
