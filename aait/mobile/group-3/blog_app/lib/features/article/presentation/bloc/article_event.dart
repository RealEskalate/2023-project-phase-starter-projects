part of 'article_bloc.dart';

sealed class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object> get props => [];
}

class GetAllArticlesEvent extends ArticleEvent {
  final String? searchQuery;
  final List tags;

  GetAllArticlesEvent({this.searchQuery = "", this.tags = const []});
}

class GetArticleEvent extends ArticleEvent {
  final String tags;
  final String searchParams;

  const GetArticleEvent({
    required this.tags,
    required this.searchParams,
  });

  @override
  List<Object> get props => [tags, searchParams];
}

class GetArticleByIdEvent extends ArticleEvent {
  final String id;
  const GetArticleByIdEvent({required this.id});
  @override
  List<Object> get props => [id];
}

class DeleteArticleEvent extends ArticleEvent {
  final String id;
  const DeleteArticleEvent({required this.id});

  @override
  List<Object> get props => [id];
}

class GetTagsEvent extends ArticleEvent {
  const GetTagsEvent();
}
