import 'package:blog_app/features/profile/domain/entity/article.dart';

class ArticleModel extends Article {
  ArticleModel(
      {required super.title,
      required super.subTitle,
      required super.createdAt,
      required super.id,
      required super.image});
  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    return ArticleModel(
        title: json["title"],
        subTitle: json["subTitle"],
        createdAt: DateTime.parse(json["createdAt"]),
        id: json["id"],
        image: json["image"]);
  }
}
