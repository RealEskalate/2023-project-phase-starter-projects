import 'package:blog_app/core/error/failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/article.dart';
import '../repositories/article_repository.dart';

class CreateArticleUseCase {
  final ArticleRepository repository;

  CreateArticleUseCase(this.repository);

  Future<Either<Failure, Article>> call(Article article) async {
    return await repository.createArticle(article);
  }
}
