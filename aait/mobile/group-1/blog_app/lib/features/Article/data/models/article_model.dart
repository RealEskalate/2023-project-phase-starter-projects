import 'dart:convert';

import 'package:equatable/equatable.dart';

import '../../domain/entities/article_enitity.dart';

class ArticleModel extends Article implements Equatable {
  ArticleModel(
      {required this.id,
      required this.title,
      required this.subTitle,
      required this.tags,
      this.user,
      required this.content,
      this.image,
      this.estimatedtime,
      this.imageCloudinaryPublicId,
      this.createdAt})
      : super(
            id: id,
            title: title,
            subTitle: subTitle,
            user: user,
            tags: tags,
            content: content,
            image: image,
            estimatedtime: estimatedtime,
            imageCloudinaryPublicId: imageCloudinaryPublicId,
            createdAt: createdAt,
            );

  @override
  final String id;
  @override
  final String title;
  @override
  final String subTitle;
  @override
  final String? user;
  @override
  final List<String> tags;
  @override
  final String content;
  @override
  final String? image;
  @override
  final String? estimatedtime;
  @override
  final String? imageCloudinaryPublicId;
  @override
  final DateTime? createdAt;

  factory ArticleModel.fromJson(Map<String, dynamic> json) {
    return ArticleModel(
        id: json['id'],
        title: json["title"],
        subTitle: json['subTitile'],
        content: json['content'],
        tags: jsonDecode(json['tags']),
        user: json['user'],
        image: json['image'],
        estimatedtime: json['estimatedReadTime'],
        imageCloudinaryPublicId: json['imageCloudinaryPublicId'],
        createdAt: json['createdAt']);
  }

  Map<String?, dynamic> toJson(ArticleModel articleModel) {
    return {
      'title': articleModel.title,
      'subTitle': articleModel.subTitle,
      'content': articleModel.content,
      'tags': jsonEncode(articleModel.tags)
    };
  }

  @override
  List<Object?> get props => [id];

  @override
  bool? get stringify => false;
}
