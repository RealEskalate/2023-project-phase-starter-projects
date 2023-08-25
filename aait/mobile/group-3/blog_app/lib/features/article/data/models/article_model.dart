import 'dart:convert';

import 'package:json_annotation/json_annotation.dart';

import '../../domain/entity/article.dart';

class ArticleModel extends Article {
  const ArticleModel({
    required super.tags,
    required super.content,
    required super.title,
    required super.subTitle,
    required super.estimatedReadTime,
    required super.user,
    required super.image,
    required super.imageCloudinaryPublicId,
    @JsonKey(fromJson: _dateTimeFromJson, toJson: _dateTimeToJson)
    required super.createdAt,
    required super.id,
  });

  ArticleModel.empty()
      : this(
          tags: ['_empty.tags'],
          content: '_empty.content',
          title: '_empty.title',
          subTitle: '_empty.subTitle',
          estimatedReadTime: '_empty.estimatedReadTime',
          user: {
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
          image: '_empty.image',
          imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
          createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
          id: '1',
        );

  Map<String, dynamic> toMap() {
    final result = <String, dynamic>{};

    result.addAll({'tags': tags});
    result.addAll({'content': content});
    result.addAll({'title': title});
    result.addAll({'subTitle': subTitle});
    result.addAll({'estimatedReadTime': estimatedReadTime});
    result.addAll({'user': user});
    result.addAll({'image': image});
    result.addAll({'imageCloudinaryPublicId': imageCloudinaryPublicId});
    result.addAll({'createdAt': createdAt.toUtc().toIso8601String()});
    result.addAll({'id': id});

    return result;
  }

  factory ArticleModel.fromMap(Map<String, dynamic> map) {
    return ArticleModel(
      tags: (map['tags'] as List<dynamic>?)?.cast<String>() ?? [],
      content: map['content'] ?? '',
      title: map['title'] ?? '',
      subTitle: map['subTitle'] ?? '',
      estimatedReadTime: map['estimatedReadTime'] ?? '',
      user: Map<String, dynamic>.from(map['user']),
      image: map['image'] ?? '',
      imageCloudinaryPublicId: map['imageCloudinaryPublicId'] ?? '',
      createdAt: _dateTimeFromJson(map['createdAt']),
      id: map['id'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory ArticleModel.fromJson(String source) =>
      ArticleModel.fromMap(json.decode(source));

  ArticleModel copyWith({
    List<String>? tags,
    String? content,
    String? title,
    String? subTitle,
    String? estimatedReadTime,
    Map<String, dynamic>? user,
    String? image,
    String? imageCloudinaryPublicId,
    DateTime? createdAt,
    String? id,
  }) {
    return ArticleModel(
        tags: tags ?? this.tags,
        content: content ?? this.content,
        title: title ?? this.title,
        subTitle: subTitle ?? this.subTitle,
        estimatedReadTime: estimatedReadTime ?? this.estimatedReadTime,
        user: user ?? this.user,
        image: image ?? this.image,
        imageCloudinaryPublicId:
            imageCloudinaryPublicId ?? this.imageCloudinaryPublicId,
        createdAt: createdAt ?? this.createdAt,
        id: id ?? this.id);
  }

  static DateTime _dateTimeFromJson(dynamic json) {
    if (json is String) {
      return DateTime.parse(json);
    }
    throw Exception("Invalid date format");
  }

  static String _dateTimeToJson(DateTime dateTime) {
    return dateTime.toUtc().toIso8601String();
  }
}
