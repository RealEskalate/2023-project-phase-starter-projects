import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/Article/domain/entities/article_enitity.dart';
import 'package:blog_app/features/Article/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';

import '../entities/create_article_entity.dart';

class UpdateArticle {
  final ArticleRepository repository;
  UpdateArticle(this.repository);

  Future<Either<Failure, Article>> use(CreateArticleEntity article) async {
    return await repository.updateArticle(article);
  }
}

