import '../../../user/data/models/user_data_model.dart';
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
    final tags =
        json['tags'].map<TagModel>((name) => TagModel(name: name)).toList();

    UserDataModel author;
    try {
      author = UserDataModel(
          id: json['user']['id'],
          fullName: json['user']['fullName'] ?? '',
          email: json['user']['email'] ?? '',
          expertise: json['user']['expertise'] ?? '',
          bio: json['user']['bio'] ?? '',
          createdAt: json['user']['createdAt'] ?? '',
          image: json['user']['image'] ?? '',
          imageCloudinaryPublicId:
              json['user']['imageCloudinaryPublicId'] ?? '',
          articles: const []);
    } catch (e) {
      author = UserDataModel(
          id: json['user'],
          fullName: '',
          email: '',
          expertise: '',
          bio: '',
          createdAt: '',
          image: '',
          imageCloudinaryPublicId: '',
          articles: const []);
    }

    return ArticleModel(
      id: json['id'],
      title: json['title'],
      subTitle: json['subTitle'],
      content: json['content'],
      estimatedReadTime: json['estimatedReadTime'],
      date: DateTime.parse(json['createdAt']),
      photoUrl: json['image'],
      author: author,
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
      'user': (author as UserDataModel).toJson(),
      'tags': tags.map((tag) => tag.name).toList(),
    };
  }
}
