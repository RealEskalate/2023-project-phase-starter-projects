import 'package:blog_app/features/user_profile/domain/entities/article.dart';
import 'package:equatable/equatable.dart';

class ArticleModel extends Article implements Equatable {
  ArticleModel(
      {required this.id,
      required this.title,
      required this.content,
      required this.authorId,
      required this.subTitle,
      this.image,
      this.tags = const []})
      : super(
          id: id,
          title: title,
          content: content,
          authorId: authorId,
          subTitle: subTitle,
          image: image,
          tags: tags,
        );

  @override
  final String id;
  @override
  final String title;
  @override
  final String subTitle;
  @override
  final String content;
  @override
  final String authorId;
  @override
  final String? image;
  @override
  final List<String> tags;

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    return ArticleModel(
        id: json["id"],
        title: json["title"],
        subTitle: json["subTitle"],
        content: json["content"],
        authorId: json["user"],
        image: json["image"],
        tags: json["tags"]);
  }

  Map<String?, dynamic> toJson(ArticleModel articleModel) {
    return {
      "id": articleModel.id,
      "title": articleModel.title,
      "subTitle": articleModel.subTitle,
      "content": articleModel.content,
      "authorId": articleModel.authorId,
      "image": articleModel.image,
      "tags": articleModel.tags
    };
  }

  @override
  List<Object?> get props =>
      [id, title, subTitle, content, authorId, image, tags];

  @override
  bool? get stringify => false;
}
