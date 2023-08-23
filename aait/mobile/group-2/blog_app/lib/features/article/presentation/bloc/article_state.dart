import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

sealed class ArticleState extends Equatable {
  const ArticleState();

  @override
  List<Object> get props => [];
}

final class ArticleInitialState extends ArticleState {}

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

final class ArticleErrorState extends ArticleState {
  final String message;

  const ArticleErrorState(this.message);

  @override
  List<Object> get props => [message];
}
