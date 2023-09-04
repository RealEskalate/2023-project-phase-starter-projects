part of 'create_article_bloc.dart';

@immutable
sealed class CreateArticleEvent extends Equatable {
  @override
  List<Object> get props => [];
}

class SendData extends CreateArticleEvent {
  final String title;
  final String subTitle;
  final String content;
  final XFile postImage;
  final List<String> tags;

  SendData({
    required this.title,
    required this.subTitle,
    required this.content,
    required this.postImage,
    required this.tags,
  });

  @override
  List<Object> get props=> [title, subTitle, content, postImage, tags];

}

class GetAllTags extends CreateArticleEvent{}

class ResetCreate extends CreateArticleEvent{}


