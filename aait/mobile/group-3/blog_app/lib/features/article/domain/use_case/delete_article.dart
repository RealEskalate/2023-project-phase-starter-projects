import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class DeleteArticleUsecase implements UseCase<Article, String>{
  final ArticleRepository _repository;

  DeleteArticleUsecase(this._repository);

  @override
  ResultFuture<Article> call(String params) async {
    return _repository.deleteArticle(params);
  } 
}