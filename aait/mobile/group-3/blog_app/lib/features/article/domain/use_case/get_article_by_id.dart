import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/use_case/usecase.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class GetArticleByIdUsecase implements UseCase<Article, String>{
  final ArticleRepository _repository;
  GetArticleByIdUsecase(this._repository);

  @override
  Future<Either<Failure, Article>> call(String params) {
    return _repository.getArticleById(params);
  }  
}