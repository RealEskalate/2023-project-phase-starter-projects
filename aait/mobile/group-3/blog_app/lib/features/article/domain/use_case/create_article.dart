import 'package:equatable/equatable.dart';

import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class CreateArticleUsecase implements UseCase<Article, CreateArticleParams> {
  const CreateArticleUsecase(this._repository);
  final ArticleRepository _repository;

  @override
  ResultFuture<Article> call(CreateArticleParams params) async {
    return _repository.createArticle(
      tags: params.tags,
      content: params.content,
      title: params.title,
      subTitle: params.subTitle,
      estimatedReadTime: params.estimatedReadTime,
      image: params.image,
    );
  }
}

class CreateArticleParams extends Equatable {
  const CreateArticleParams({
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.image,
  });

  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final String image;

   CreateArticleParams.empty()
      : this(
          tags: ['_empty.tags'],
          content: '_empty.content',
          title: '_empty.title',
          subTitle: '_empty.subTitle',
          estimatedReadTime: '_empty.estimatedReadTime',
          image: '_empty.image',
        );

  @override
  List<Object?> get props =>
      [tags, content, title, subTitle, estimatedReadTime, image];
}
