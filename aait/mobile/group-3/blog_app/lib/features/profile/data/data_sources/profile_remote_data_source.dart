import 'dart:convert';

import 'package:blog_app/core/error/exception.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:http/http.dart' as http;

abstract class ProfileRemoteDataSource {
  Future<Profile> getProfile();
}

class ProfileRemoteDataSourceImpl implements ProfileRemoteDataSource {
  final http.Client client;
  final String url = 'https://blog-api-4z3m.onrender.com/api/v1/user';
  final token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZTI3YTZhYjZjYmM2ZjU2ZTNhOGE2NiIsImlhdCI6MTY5Mjk0MjUxOCwiZXhwIjoxNjk1NTM0NTE4fQ.B7S3GR_7fkn8Fa4g3fZqTArhQgmaK-FyJztnDkDM06k";
  ProfileRemoteDataSourceImpl({required this.client});
  @override
  Future<Profile> getProfile() async {
    final result = await client
        .get(Uri.parse(url), headers: {"Authorization": "Bearer $token"});
    if (result.statusCode == 200) {
      final jsonResponse = jsonDecode(result.body);
      final ProfileModel profile = ProfileModel.fromJson(jsonResponse);
      return profile;
    } else if (result.statusCode == 401) {
      return _getDummyProfile();
    } else {
      throw ServerException();
    }
  }

  _getDummyArticles() {
    final List<Article> _articles = [
      Article(
          title: "GAME",
          subTitle: "Why Elden ring is the best game ever made",
          createdAt: DateTime(2023, 8, 20),
          id: "gashbvSAahnvbvsfw",
          image:
              "https://www.techspot.com/images2/news/bigimage/2022/03/2022-03-17-image-37.jpg"),
      Article(
          title: "SPACE",
          subTitle: "How are galaxies constantly expanding",
          createdAt: DateTime(2023, 8, 22, 12),
          id: "bsdrnvjwnvwjsd",
          image:
              "https://t4.ftcdn.net/jpg/05/51/96/35/360_F_551963598_53hrJ2UXDoC00XhkqJ8lKN8Xa2EQg4no.jpg"),
      Article(
          title: "VALHEIM",
          subTitle: "Valheim next biggest update is the ocean",
          createdAt: DateTime(2023, 8, 22, 16),
          id: "bsdrnvfdsfgdgfgfdd",
          image:
              "https://i.etsystatic.com/24434904/r/il/b2ba6a/4092042802/il_fullxfull.4092042802_q13p.jpg")
    ];
    return _articles;
  }

  _getDummyProfile() {
    List<Article> _bookmarkArticles = _getDummyArticles();
    _bookmarkArticles.add(Article(
          title: "Skyrim",
          subTitle: "How to get dragon armor in skyrim ",
          createdAt: DateTime(2022, 11, 29),
          id: "xbzvsasgbvsrewg",
          image:
              "https://standardof.net/wp-content/uploads/2020/09/Dragonscale-Armor-Set-The-Elder-Scrolls-V-Skyrim.png"));
    final Profile _profile = Profile(
        bookmarks: _bookmarkArticles,
        username: "@joevidan",
        fullName: "Jovi Daniel",
        bio:
            "Madison Blackstone is a director of user experience design, with experience managing global teams.",
        imageName:
            "https://images.pexels.com/photos/2379004/pexels-photo-2379004.jpeg?cs=srgb&dl=pexels-italo-melo-2379004.jpg&fm=jpg",
        expertise: "UX Designer",
        articles: _getDummyArticles());
    return _profile;
  }
}
