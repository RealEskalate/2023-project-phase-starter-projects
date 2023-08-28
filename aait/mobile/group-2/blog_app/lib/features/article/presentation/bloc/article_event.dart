import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

sealed class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object?> get props => [];
}

final class LoadAllArticlesEvent extends ArticleEvent {}

final class LoadAllTagsEvent extends ArticleEvent {}

final class GetSingleArticleEvent extends ArticleEvent {
  final String id;

  const GetSingleArticleEvent(this.id);

  @override
  List<Object> get props => [id];
}

final class CreateArticleEvent extends ArticleEvent {
  final Article article;

  const CreateArticleEvent(this.article);

  @override
  List<Object?> get props => [article];
}

final class UpdateArticleEvent extends ArticleEvent {
  final Article article;

  const UpdateArticleEvent(this.article);

  @override
  List<Object?> get props => [article];
}

final class DeleteArticleEvent extends ArticleEvent {
  final String id;

  const DeleteArticleEvent(this.id);

  @override
  List<Object> get props => [id];
}
