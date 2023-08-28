import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';

import 'package:blog_app/features/article/data/models/article_model.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';

import '../../../../fixtures/fixture_reader.dart';

void main() {
  final tModel = ArticleModel.empty();

  test("should be a subclass of [Article] entity", () {
    // Assert
    expect(tModel, isA<Article>());
  });

  final tJson = fixtures('article.json');
  final tMap = jsonDecode(tJson) as Map<String, dynamic>;
  final tMapData = tMap['data'][0];
  final tJsonData = jsonEncode(tMapData);

  group('fromMap', () {
    test("should return an [ArticleModel] with the right data", () {
      // Arrange
      // Act
      final result = ArticleModel.fromMap(tMapData);
      // Assert
      expect(result, equals(tModel));
    });
  });

  group('fromJson', () {
    test("should return [ArticleModel] with the right data", () async {
      // Arrange

      // Act
      final result = ArticleModel.fromJson(jsonDecode(tJsonData));
      // Assert
      expect(result, equals(tModel));
    });
  });

  group('toMap', () {
    test("should return a [Map] with the right data", () {
      // Arrange
      final expectedMap = {
        'tags': ['_empty.tags'],
        'content': '_empty.content',
        'title': '_empty.title',
        'subTitle': '_empty.subTitle',
        'estimatedReadTime': '_empty.estimatedReadTime',
        'user': {
          '_id': '64e25674bfc65d390e781205',
          'fullName': 'Tamirat Dereje',
          'email': 'tamiratdereje@gmail.com',
          'expertise': 'designer',
          'bio': 'I am passionate designer who see beauty in everything',
          'createdAt': '2023-08-20T18:07:48.829Z',
          '__v': 0,
          'image':
              'https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg',
          'imageCloudinaryPublicId': 'guf4tul1ftar9hdpnaev',
          'id': '64e25674bfc65d390e781205'
        },
        'image': '_empty.image',
        'imageCloudinaryPublicId': '_empty.imageCloudinaryPublicId',
        'createdAt': '2023-08-20T19:36:03.414Z',
        'id': '1'
      };
      // Act
      final result = tModel.toMap();
      // Assert
      expect(result, equals(expectedMap));
    });
  });

  group('toJson', () {
    test("should return a [JSON] string with the right data", () async {
      // Arrange
      final expected = jsonEncode({
        "tags": ["_empty.tags"],
        "content": "_empty.content",
        "title": "_empty.title",
        "subTitle": "_empty.subTitle",
        "estimatedReadTime": "_empty.estimatedReadTime",
        "user": {
          "_id": "64e25674bfc65d390e781205",
          "fullName": "Tamirat Dereje",
          "email": "tamiratdereje@gmail.com",
          "expertise": "designer",
          "bio": "I am passionate designer who see beauty in everything",
          "createdAt": "2023-08-20T18:07:48.829Z",
          "__v": 0,
          "image":
              "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
          "imageCloudinaryPublicId": "guf4tul1ftar9hdpnaev",
          "id": "64e25674bfc65d390e781205"
        },
        "image": "_empty.image",
        "imageCloudinaryPublicId": "_empty.imageCloudinaryPublicId",
        "createdAt": "2023-08-20T19:36:03.414Z",
        "id": "1"
      });
      // Act
      final result = tModel.toJson();
      // Assert
      expect(result, expected);
    });
  });

  group('copyWith', () {
    test("should return [ArticleModel] with different data",
       () async {
      // Arrange
      // Act
      final result = tModel.copyWith(title: "Newww Title");
      // Assert
      expect(result.title, equals("Newww Title"));
    });
   });
}
