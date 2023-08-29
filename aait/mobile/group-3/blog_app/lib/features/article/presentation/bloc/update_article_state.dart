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

final class UpdateArticleLoaded extends UpdateArticleState {
  final String articleId;
  final TextEditingController content;
  final TextEditingController title;
  final TextEditingController subTitle;
  final TextEditingController photoImage;

  UpdateArticleLoaded({
    required this.articleId,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.photoImage,
  });

  List<Object> get props => [articleId, content, title, subTitle, photoImage];
}

final class UpdateArticleResult extends UpdateArticleState {
  final Article article;

  UpdateArticleResult({required this.article});

  List<Object> get props => [article];
}

final class UpdateArticleError extends UpdateArticleState {
  final String message;
  UpdateArticleError({required this.message});
}
