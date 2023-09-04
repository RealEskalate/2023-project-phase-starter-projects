import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:equatable/equatable.dart';

class Profile extends Equatable {
  final String username;
  final String fullName;
  final String imageName;
  final String expertise;
  final String bio;
  final List<Article> articles;
  final List<Article> bookmarks;
  final String id;

  Profile({
    required this.username,
    required this.bookmarks,
    required this.articles,
    required this.fullName,
    required this.imageName,
    required this.expertise,
    required this.bio,
    required this.id,
  });

  Profile copyWith({
    String? username,
    String? fullName,
    String? imageName,
    String? expertise,
    String? bio,
    List<Article>? bookmarks,
    List<Article>? articles,
    String? id,
  }) {
    return Profile(
      username: username ?? this.username,
      articles: articles ?? this.articles,
      fullName: fullName ?? this.fullName,
      imageName: imageName ?? this.imageName,
      bio: bio ?? this.bio,
      bookmarks: bookmarks ?? this.bookmarks,
      expertise: expertise ?? this.expertise,
      id: id ?? this.id,
    );
  }

  @override
  List<Object> get props =>
      [username, fullName, imageName, expertise, articles, id];
}
