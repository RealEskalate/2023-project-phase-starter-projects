import 'dart:convert';

import 'package:blog_app/features/profile/data/models/article_model.dart';
import 'package:blog_app/features/profile/data/models/profile_model.dart';
import 'package:blog_app/features/profile/domain/entity/profile.dart';
import 'package:flutter_test/flutter_test.dart';

import '../../../../fixtures/fixture.dart';

void main() {
  final tProfileModel = ProfileModel(
    bookmarks: [],
      username: "@tamiratdereje",
      articles: [
        ArticleModel(
            title: "Workout",
            subTitle: "Triceps",
            createdAt: DateTime(2023, 8, 20),
            id: "64e26b23fe68a176cdbc52c4",
            image:
                "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692560163/usay3yegvnh0abxfslvh.png")
      ],
      fullName: "Tamirat Dereje",
      imageName:
          "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
      expertise: "designer",
      bio: "I am passionate designer who see beauty in everything");
  test("Should be a sub-type of Profile entity", () {
    expect(tProfileModel, isA<Profile>());
  });

  group('fromJson', () {
    test("Should output a valid ProfileModel", () async {
      final Map<String, dynamic> jsonMap =
          await jsonDecode(fixture('profile.json'));
      final result = ProfileModel.fromJson(jsonMap);
      expect(result, equals(tProfileModel));
    });
  });
}
