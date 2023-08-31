import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

 class ArticleState extends Equatable {
  const ArticleState();

  @override
  List<Object> get props => [];
}

 class ArticleInitialState extends ArticleState {}

 class ArticleLoadingState extends ArticleState {}

 class SingleArticleLoadedState extends ArticleState {
  final Article article;

  const SingleArticleLoadedState(this.article);

  @override
  List<Object> get props => [article];
}

 class AllArticlesLoadedState extends ArticleState {
  final List<Article> articles;

  const AllArticlesLoadedState(this.articles);

  @override
  List<Object> get props => [articles];
}

 class AllArticlesFilteredState extends ArticleState {
  final List<Article> articles;

  const AllArticlesFilteredState(this.articles);

  @override
  List<Object> get props => [articles];
}

 class ArticleErrorState extends ArticleState {
  final String message;

  const ArticleErrorState(this.message);

  @override
  List<Object> get props => [message];
}
 class ArticleCreatedState extends ArticleState {
  final Article article;

  const ArticleCreatedState(this.article);

  @override
  List<Object> get props => [article];
}