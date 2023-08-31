part of 'article_bloc.dart';

sealed class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object> get props => [];
}

class CreateArticleEvent extends ArticleEvent {
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final XFile image;

  const CreateArticleEvent({
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.image,
  });

  @override
  List<Object> get props =>
      [tags, content, title, subTitle, estimatedReadTime, image];
}

class GetAllArticlesEvent extends ArticleEvent {
  final String? searchQuery;
  final List tags;

   GetAllArticlesEvent({this.searchQuery = "", this.tags = const [] });
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

class UpdateArticleEvent extends ArticleEvent {
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final XFile image;
  final String id;

  const UpdateArticleEvent({
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.image,
    required this.id,
  });

  @override
  List<Object> get props =>
      [tags, content, title, subTitle, estimatedReadTime, image, id];
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
