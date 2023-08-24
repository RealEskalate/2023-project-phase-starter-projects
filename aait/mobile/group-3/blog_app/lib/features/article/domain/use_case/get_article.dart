import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class GetArticleUsecase implements UseCase<Article, String>{
  final ArticleRepository _repository;

  GetArticleUsecase(this._repository);

  @override
  ResultFuture<Article> call(String params) {
    return _repository.getArticle(params);
  }
}