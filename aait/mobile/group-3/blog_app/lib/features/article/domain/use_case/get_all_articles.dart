import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class GetAllArticlesUsecase implements UseCase<List<Article>, NoParams> {
  final ArticleRepository _repository;
  
  GetAllArticlesUsecase(this._repository);

  @override
  ResultFuture<List<Article>> call(NoParams params) async {
    return _repository.getAllArticles();
  }
}
