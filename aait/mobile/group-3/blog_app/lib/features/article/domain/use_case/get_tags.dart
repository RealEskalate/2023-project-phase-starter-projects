import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../repository/article_repository.dart';

class GetTagsUsecase implements UseCase<List<String>, NoParams>{
  final  ArticleRepository _repository;

  GetTagsUsecase(this._repository); 

  @override
  ResultFuture<List<String>> call(NoParams params) async {
    return _repository.getTags();
  } 
}