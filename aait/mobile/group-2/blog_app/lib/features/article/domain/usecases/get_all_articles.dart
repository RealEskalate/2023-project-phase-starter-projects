import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetAllArticles implements UseCase<List<Article>, NoParams> {
  final ArticleRepository repository;

  GetAllArticles(this.repository);

  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getAllArticles();
  }

}

