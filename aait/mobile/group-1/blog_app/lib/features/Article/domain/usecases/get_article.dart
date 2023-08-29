import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/Article/domain/entities/article_enitity.dart';
import 'package:blog_app/features/Article/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';

class GetArticle {
  final ArticleRepository repository;
  GetArticle(this.repository);

  Future<Either<Failure, Article>> use(
      String id) async {
    return await repository.getArticle(id);
  }
}
