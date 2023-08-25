import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:equatable/equatable.dart';

class Profile extends Equatable {
  final String username;
  final String fullName;
  final String imageName;
  final String expertise;
  final String bio;
  final List<Article> articles;

  Profile(
      {required this.username,
      required this.articles,
      required this.fullName,
      required this.imageName,
      required this.expertise,
      required this.bio});

  Profile copyWith(
      {String? username,
      String? fullName,
      String? imageName,
      String? expertise,
      String? bio,
      List<Article>? articles}) {
    return Profile(
        username: username ?? this.username,
        articles: articles ?? this.articles,
        fullName: fullName ?? this.fullName,
        imageName: imageName ?? this.imageName,
        bio: bio ?? this.bio,
        expertise: expertise ?? this.expertise);
  }

  @override
  List<Object> get props =>
      [username, fullName, imageName, expertise, articles];
}
