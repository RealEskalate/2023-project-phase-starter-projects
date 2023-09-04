part of 'update_article_bloc.dart';

@immutable
sealed class UpdateArticleState extends Equatable {
  @override
  List<Object> get props => [];
}

final class UpdateArticleInitial extends UpdateArticleState {
  @override
  List<Object> get props => [];
}

final class UpdateArticleLoading extends UpdateArticleState {}

final class GetTagsLoading extends UpdateArticleState{}

final class UpdateArticleLoaded extends UpdateArticleState {
  final String articleId;
  final TextEditingController content;
  final TextEditingController title;
  final TextEditingController subTitle;
  final String photoImage;
  final List<String> availableTags;
  final List<String> selectedTags;

  UpdateArticleLoaded({
    required this.articleId,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.photoImage,
    required this.availableTags,
    required this.selectedTags
  });

  @override
  List<Object> get props => [articleId, content, title, subTitle, photoImage, availableTags, selectedTags];
}

final class UpdateArticleResult extends UpdateArticleState {
  final Article article;

  UpdateArticleResult({required this.article});

  @override
  List<Object> get props => [article];
}

final class AllTagsLoaded extends UpdateArticleState{
  final List<String> tags;

  AllTagsLoaded({required this.tags});

  @override
  List<Object> get props => [tags];
}

final class UpdateArticleError extends UpdateArticleState {
  final String message;
  UpdateArticleError({required this.message});

  @override
  List<String> get props => [message];
}

