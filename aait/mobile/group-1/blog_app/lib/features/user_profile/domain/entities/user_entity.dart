import 'article.dart';

class User {
  User(
      {required this.id,
      required this.fullName,
      required this.email,
      this.expertise,
      this.bio,
      this.image,
      this.articles = const []});
  final String id;
  final String fullName;
  final String email;
  final String? expertise;
  final String? bio;
  final String? image;
  List<Article> articles = [];

  // the copywith method is used to create a new user object with the updated values

  User copyWith(
      {String? id,
      String? fullName,
      String? email,
      String? expertise,
      String? bio,
      String? image,
      List<Article>? articles}) {
    return User(
        id: id ?? this.id,
        fullName: fullName ?? this.fullName,
        email: email ?? this.email,
        expertise: expertise ?? this.expertise,
        bio: bio ?? this.bio,
        image: image ?? this.image,
        articles: articles ?? this.articles);
  }
}
