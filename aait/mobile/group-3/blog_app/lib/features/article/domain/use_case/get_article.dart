import 'package:equatable/equatable.dart';

import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class GetArticleUsecase implements UseCase<List<Article>, GetArticleParams>{
  final ArticleRepository _repository;

  GetArticleUsecase(this._repository);

  @override
  ResultFuture<List<Article>> call(GetArticleParams params) async {
    return _repository.getArticle(
      tags: params.tags,
      searchParams: params.searchParams,
    );
  }
}

class GetArticleParams extends Equatable{
  final String tags;
  final String searchParams;
  const GetArticleParams({
    required this.tags,
    required this.searchParams,
  });

  const GetArticleParams.empty()
    :this(
      tags: 'Other',
      searchParams: 'searchParams'
    );

  @override
  List<Object?> get props => [tags, searchParams];
  }