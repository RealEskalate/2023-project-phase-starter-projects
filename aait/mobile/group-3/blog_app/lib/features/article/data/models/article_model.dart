import 'dart:convert';

import 'user_model.dart';
import '../../domain/entity/user.dart';

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
          user: UserModel.empty(),
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
    result.addAll({'photo': image});

    return result;
  }

  factory ArticleModel.fromMap(Map<String, dynamic> map) {
    return ArticleModel(
      tags: (map['tags'] as List<dynamic>?)?.cast<String>() ?? [],
      content: map['content'] ?? 'No Content',
      title: map['title'] ?? 'No Title',
      subTitle: map['subTitle'] ?? 'No subTitle',
      estimatedReadTime: map['estimatedReadTime'] ?? 'No Etimated Read Time',
      user: UserModel.fromJson(map['user']),
      image: map['image'] ?? '',
      imageCloudinaryPublicId:
          map['imageCloudinaryPublicId'] ?? 'No imageCloudinaryPublicId',
      createdAt: _dateTimeFromJson(map['createdAt']),
      id: map['id'] ?? 'No Id',
    );
  }

  String toJson() => json.encode(toMap());

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    final resTags = json['tags'] ?? [];
    print(resTags);

    return ArticleModel(
      tags: resTags.map<String>((e) => e.toString()).toList(),
      content: json['content'] ?? "No Content",
      title: json['title'] ?? "No Title",
      subTitle: json['subTitle'] ?? "No subTitle",
      estimatedReadTime: json['estimatedReadTime'] ?? "5 min",
      user: json['user'] is String
          ? UserModel.empty()
          : UserModel.fromJson(json['user']),
      image: json['image'] ?? "",
      imageCloudinaryPublicId:
          json['imageCloudinaryPublicId'] ?? "No imageCloudinaryPublicId",
      createdAt: _dateTimeFromJson(json['createdAt']),
      id: json['id'] ?? "No ID",
    );
  }

  ArticleModel copyWith({
    List<String>? tags,
    String? content,
    String? title,
    String? subTitle,
    String? estimatedReadTime,
    User? user,
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
    try {
      if (json is String) {
        return DateTime.parse(json);
      } else {
        return DateTime.now();
      }
    } catch (e) {
      return DateTime.now();
    }
  }

  static String _dateTimeToJson(DateTime dateTime) {
    return dateTime.toUtc().toIso8601String();
  }
}
