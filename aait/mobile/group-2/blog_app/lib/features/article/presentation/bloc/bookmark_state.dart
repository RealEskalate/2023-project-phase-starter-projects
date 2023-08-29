import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

sealed class BookmarkState extends Equatable {
  const BookmarkState();

  @override
  List<Object> get props => [];
}

final class BookmarkInitialState extends BookmarkState {}

final class BookmarkLoadingState extends BookmarkState {}

final class BookmarkLoadedState extends BookmarkState {
  final List<Article> articles;

  const BookmarkLoadedState(this.articles);

  @override
  List<Object> get props => [articles];
}

final class BookmarkAddedState extends BookmarkState {
  final Article article;

  const BookmarkAddedState(this.article);

  @override
  List<Object> get props => [article];
}

final class BookmarkRemovedState extends BookmarkState {
  final Article article;

  const BookmarkRemovedState(this.article);

  @override
  List<Object> get props => [article];
}

final class BookmarkErrorState extends BookmarkState {
  final String message;

  const BookmarkErrorState(this.message);

  @override
  List<Object> get props => [message];
}
