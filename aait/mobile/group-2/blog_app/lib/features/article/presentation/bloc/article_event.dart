import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';
import '../../domain/entities/tag.dart';

sealed class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object?> get props => [];
}

final class LoadAllArticlesEvent extends ArticleEvent {}

final class FilterArticlesEvent extends ArticleEvent {
  final Tag tag;
  final String searchParams;

  const FilterArticlesEvent(this.tag, this.searchParams);

  @override
  List<Object?> get props => [tag, searchParams];
}

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
