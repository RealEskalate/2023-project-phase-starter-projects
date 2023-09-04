import 'package:blog_app/features/profile/data/models/article_model.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';

class ProfileModel extends Profile {
  ProfileModel({
    required String username,
    required List<Article> articles,
    required String fullName,
    required String imageName,
    required String expertise,
    required String bio,
    required List<Article> bookmarks,
    required String id,
  }) : super(
          username: username,
          articles: articles,
          bookmarks: bookmarks,
          fullName: fullName,
          imageName: imageName,
          expertise: expertise,
          bio: bio,
          id: id,
        );

  factory ProfileModel.fromJson(Map<String, dynamic> jsonMap) {
    final Map<String, dynamic> dataJson = jsonMap["data"];
    String fullName = dataJson["fullName"];
    List<String> nameParts = fullName.split(' ');
    String modifiedUsername =
        '@' + nameParts.map((e) => e.toLowerCase()).join('');
    List<Article> articleList = dataJson["articles"]
        .map<Article>((e) => ArticleModel.fromJson(e))
        .toList();
    String id = dataJson["id"];

    return ProfileModel(
      username: modifiedUsername,
      articles: articleList,
      fullName: dataJson["fullName"],
      imageName: dataJson["image"] ??
          "https://wallpapers.com/images/hd/naruto-pictures-59j4py5kpauv4mgu.jpg",
      expertise: dataJson["expertise"],
      bio: dataJson["bio"],
      bookmarks: [],
      id: id,
    );
  }
}
