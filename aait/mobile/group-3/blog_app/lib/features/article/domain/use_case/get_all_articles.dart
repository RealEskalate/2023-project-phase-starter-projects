import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/use_case/usecase.dart';
import '../entity/article.dart';
import '../entity/getArticlesEntity.dart';
import '../repository/article_repository.dart';

class GetAllArticlesUsecase implements UseCase<List<Article>, ArticleRequest > {
  final ArticleRepository _repository;
  
  GetAllArticlesUsecase(this._repository);

  @override
  Future<Either<Failure, List<Article>>> call(ArticleRequest params) async {
    return _repository.getAllArticles(params);
  }
}
