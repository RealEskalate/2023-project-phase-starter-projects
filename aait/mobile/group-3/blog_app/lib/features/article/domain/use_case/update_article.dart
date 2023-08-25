import 'package:equatable/equatable.dart';

import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../repository/article_repository.dart';

class UpdateArticleUsecase implements UseCase<Article, UpdateArticleParams> {
  final ArticleRepository _repository;
  UpdateArticleUsecase(this._repository);
  @override
  ResultFuture<Article> call(UpdateArticleParams params) async {
    return _repository.updateArticle(
      id: params.id,
      tags: params.tags,
      content: params.content,
      title: params.title,
      subTitle: params.subTitle,
      estimatedReadTime: params.estimatedReadTime,
      image: params.image,
    );
  }
}

class UpdateArticleParams extends Equatable {
  final String id;
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final String image;

  const UpdateArticleParams({
    required this.id,
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.image,
  });

  UpdateArticleParams.empty()
      : this(
        id: "1",
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
