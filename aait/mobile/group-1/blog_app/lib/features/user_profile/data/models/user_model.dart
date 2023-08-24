import 'package:blog_app/features/user_profile/domain/entities/article.dart';
import 'package:equatable/equatable.dart';

import '../../domain/entities/user_entity.dart';

class UserModel extends User implements Equatable {
  UserModel(
      {required this.id,
      required this.fullName,
      required this.email,
      this.expertise,
      this.bio,
      this.image,
      this.articles = const []})
      : super(
            id: id,
            fullName: fullName,
            email: email,
            expertise: expertise,
            bio: bio,
            image: image);

  @override
  final String id;
  @override
  final String fullName;
  @override
  final String email;
  @override
  final String? expertise;
  @override
  final String? bio;
  @override
  final String? image;
  @override
  final List<Article> articles;

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
        id: json['id'],
        fullName: json['fullName'],
        email: json['email'],
        expertise: json['expertise'],
        bio: json['bio'],
        image: json['image'],
        articles: json['articles']);
  }

  Map<String?, dynamic> toJson(UserModel userModel) {
    return {
      "id": userModel.id,
      "fullName": userModel.fullName,
      "email": userModel.email,
      "expertise": userModel.expertise,
      "bio": userModel.bio,
      "image": userModel.image,
      "articles": userModel.articles
    };
  }

  @override
  List<Object?> get props => [id];

  @override
  bool? get stringify => false;
}
