import '../../../article/data/models/article_mapper.dart';
import '../../../article/data/models/article_model.dart';
import '../../domain/entities/user_data.dart';

class UserDataModel extends UserData {
  const UserDataModel({
    required super.id,
    required super.fullName,
    required super.email,
    required super.expertise,
    required super.bio,
    required super.createdAt,
    required super.image,
    required super.imageCloudinaryPublicId,
    required super.articles,
  });

  factory UserDataModel.fromJson(Map<String, dynamic> json) {
    return UserDataModel(
      id: json['id'],
      fullName: json['fullName'],
      email: json['email'],
      expertise: json['expertise'],
      bio: json['bio'],
      createdAt: json['createdAt'],
      image: json['image'] ?? '',
      imageCloudinaryPublicId: json['imageCloudinaryPublicId'] ?? '',
      articles: json['articles'] == null
          ? const []
          : json['articles']
              .map<ArticleModel>((m) => ArticleModel.fromJson(m))
              .toList(),
    );
  }
  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'fullName': fullName,
      'email': email,
      'expertise': expertise,
      'bio': bio,
      'createdAt': createdAt,
      'image': image,
      'imageCloudinaryPublicId': imageCloudinaryPublicId,
      'articles': articles.map((e) => e.toArticleModel().toJson()).toList(),
    };
  }
}
