import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../repository/article_repository.dart';

class DeleteArticleUsecase implements UseCase<void, String>{
  final ArticleRepository _repository;

  DeleteArticleUsecase(this._repository);

  @override
  ResultFuture<void> call(String params) async {
    return _repository.deleteArticle(params);
  } 
}