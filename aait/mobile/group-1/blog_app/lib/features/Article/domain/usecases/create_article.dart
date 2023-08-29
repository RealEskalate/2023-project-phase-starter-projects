import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures/failure.dart';
import '../entities/article_enitity.dart';
import '../entities/create_article_entity.dart';
import '../repositories/article_repository.dart';

class CreateArticle {
  final ArticleRepository repository;
  CreateArticle(this.repository);

  Future<Either<Failure, Article>> use(CreateArticleEntity article) async {
    return await repository.createArticle(article);
  }
}

