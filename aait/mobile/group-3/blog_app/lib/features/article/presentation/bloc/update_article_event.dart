part of 'update_article_bloc.dart';

@immutable
sealed class UpdateArticleEvent extends Equatable {
  @override
  List<Object> get props => [];
}

class UpdateData extends UpdateArticleEvent {
  final String title;
  final String subTitle;
  final String content;
  final XFile? postImage;
  final List<String> tags;
  final String id;

  UpdateData({
    required this.title,
    required this.subTitle,
    required this.content,
    required this.postImage,
    required this.tags,
    required this.id,
  });

  @override
  List<Object> get props => [title, subTitle, content, tags, id];
}

class GetArticleData extends UpdateArticleEvent {
  final String id;
  GetArticleData({required this.id});

  @override
  List<Object> get props => [id];
}

// class GetAvailableTags extends UpdateArticleEvent {}

class ResetUpdateField extends UpdateArticleEvent {
  final String id;

  ResetUpdateField({required this.id});
  @override
  List<Object> get props => [id];
}
