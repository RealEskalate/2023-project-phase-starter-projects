import 'package:equatable/equatable.dart';

import '../../../article/domain/entities/article.dart';

class UserData extends Equatable {
  final String id;
  final String fullName;
  final String email;
  final String expertise;
  final String bio;
  final String createdAt;
  final String image;
  final String imageCloudinaryPublicId;
  final List<Article> articles;

  const UserData({
    required this.id,
    required this.fullName,
    required this.email,
    required this.expertise,
    required this.bio,
    required this.createdAt,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.articles,
  });

  static get empty => const UserData(
      articles: [],
      bio: '',
      createdAt: '',
      email: '',
      expertise: '',
      fullName: '',
      id: '',
      image: '',
      imageCloudinaryPublicId: '');

  @override
  List<Object?> get props => [
        id,
        fullName,
        email,
        expertise,
        bio,
        createdAt,
        image,
        imageCloudinaryPublicId,
        articles
      ];
}
