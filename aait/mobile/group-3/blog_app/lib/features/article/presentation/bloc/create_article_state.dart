part of 'create_article_bloc.dart';

@immutable
sealed class CreateArticleState extends Equatable {
  @override
  List<Object> get props => [];
}

final class CreateArticleInitial extends CreateArticleState {
  
}

final class CreateArticleLoading extends CreateArticleState {}

final class GetAllTagsLoading extends CreateArticleState {}

final class CreateArticleResult extends CreateArticleState {
  final Article article;

  CreateArticleResult({required this.article});

  @override
  List<Object> get props => [article];
}

final class AllTagsLoaded extends CreateArticleState{
  final List<String> tags;
  final TextEditingController content;
  final TextEditingController title;
  final TextEditingController subTitle;
  final String photoImage;
  final List<String> selectedTags;

  AllTagsLoaded({
    required this.content,
    required this.title,
    required this.subTitle,
    required this.photoImage,
    required this.tags,
    this.selectedTags = const [],
  });

  @override
  List<Object> get props => [content, title, subTitle, photoImage,tags];
}

final class CreateArticleError extends CreateArticleState {
  final String errorMessage;

  CreateArticleError({required this.errorMessage});
}


