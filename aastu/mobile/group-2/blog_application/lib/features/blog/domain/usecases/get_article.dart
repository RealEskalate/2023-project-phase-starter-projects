import 'package:blog_application/core/exceptions/Failure.dart';
import 'package:blog_application/features/blog/domain/entities/article.dart';
import 'package:blog_application/features/blog/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';

class GetArticleUseCase {
  final ArticleRepository repository;
  GetArticleUseCase(this.repository);

  Future<Either<Article, Failure>> call(String id) async {
    return repository.getArticle(id);
  }
}
