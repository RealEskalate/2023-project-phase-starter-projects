import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';
import '../../domain/entities/tag.dart';

sealed class ArticleState extends Equatable {
  const ArticleState();

  @override
  List<Object> get props => [];
}

final class ArticleInitialState extends ArticleState {}

final class ArticleLoadingState extends ArticleState {}

final class TagLoadingState extends ArticleState {}

final class SingleArticleLoadedState extends ArticleState {
  final Article article;

  const SingleArticleLoadedState(this.article);

  @override
  List<Object> get props => [article];
}

final class AllArticlesLoadedState extends ArticleState {
  final List<Article> articles;

  const AllArticlesLoadedState(this.articles);

  @override
  List<Object> get props => [articles];
}

final class AllTagsLoadedState extends ArticleState {
  final List<Tag> tags;

  const AllTagsLoadedState(this.tags);

  @override
  List<Object> get props => [tags];
}

final class ArticleCreatedState extends ArticleState {
  final Article article;

  const ArticleCreatedState(this.article);

  @override
  List<Object> get props => [article];
}

final class ArticleUpdatedState extends ArticleState {
  final Article article;

  const ArticleUpdatedState(this.article);

  @override
  List<Object> get props => [article];
}

final class ArticleDeletedState extends ArticleState {
  final Article article;

  const ArticleDeletedState(this.article);

  @override
  List<Object> get props => [article];
}

final class ArticleErrorState extends ArticleState {
  final String message;

  const ArticleErrorState(this.message);

  @override
  List<Object> get props => [message];
}
