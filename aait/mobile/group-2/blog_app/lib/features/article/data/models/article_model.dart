import '../../domain/entities/article.dart';
import 'tag_model.dart';

class ArticleModel extends Article {
  const ArticleModel(
      {required super.id,
      required super.title,
      required super.subTitle,
      required super.content,
      required super.date,
      required super.photoUrl,
      required super.author,
      required super.tags,
      required super.estimatedReadTime});

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    final tags = (json['tags'] as List<String>)
        .map<TagModel>((name) => TagModel(name: name))
        .toList();

    return ArticleModel(
      id: json['id'],
      title: json['title'],
      subTitle: json['subTitle'],
      content: json['content'],
      estimatedReadTime: json['estimatedReadTime'],
      date: json['createdAt'],
      photoUrl: json['image'],
      author: json['user'],
      tags: tags,
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'subTitle': subTitle,
      'content': content,
      'estimatedReadTime': estimatedReadTime,
      'createdAt': date.toIso8601String(),
      'image': photoUrl,
      'user': author,
      'tags': tags.map((tag) => tag.name).toList(),
    };
  }
}
