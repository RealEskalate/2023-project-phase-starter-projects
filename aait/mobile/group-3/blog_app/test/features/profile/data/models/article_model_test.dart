import 'dart:convert';

import 'package:blog_app/features/profile/data/models/article_model.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:flutter_test/flutter_test.dart';

import '../../../../fixtures/fixture.dart';

void main() {
  final tArticleModel = ArticleModel(
      title: "", subTitle: "", createdAt: DateTime(2022), id: "", image: "");
  test("Should be a sub-type of Article entity", () {
    expect(tArticleModel, isA<Article>());
  });

  group('fromJson', () {
    final tArticleModel = ArticleModel(
        title: "Workout",
        subTitle: "Triceps",
        createdAt: DateTime(2023, 8, 20),
        id: "64e26b23fe68a176cdbc52c4",
        image:
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692560163/usay3yegvnh0abxfslvh.png");
    test('Should output a valid ArticleModel', () async {
      final json = jsonDecode(fixture('profile.json'))["data"]["articles"];
      final articleList =
          json.map<Article>((e) => ArticleModel.fromJson(e)).toList();
      final result = articleList[0];
      expect(result, equals(tArticleModel));
    });
  });
}
