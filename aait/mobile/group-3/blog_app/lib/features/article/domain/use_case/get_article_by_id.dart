import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class GetArticleByIdUsecase implements UseCase<Article, String>{
  final ArticleRepository _repository;

  GetArticleByIdUsecase(this._repository);

  @override
  ResultFuture<Article> call(String id) {
    return _repository.getArticleById(id);
  }
}