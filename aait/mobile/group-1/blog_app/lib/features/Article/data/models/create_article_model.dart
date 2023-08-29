import 'dart:convert';

import 'package:equatable/equatable.dart';

import '../../domain/entities/create_article_entity.dart';

class CreateArticleModel extends CreateArticleEntity implements Equatable {
  CreateArticleModel({
    required this.title,
    required this.subTitle,
    required this.tags,
    required this.content,
    this.id,
    required this.image,
    required this.estimatedtime,
  }) : super(
          title: title,
          subTitle: subTitle,
          tags: tags,
          content: content,
          image: image,
          estimatedtime: estimatedtime,
        );

  @override
  final String title;
  @override
  final String subTitle;
  @override
  final String? id;
  @override
  final List<String> tags;
  @override
  final String content;
  @override
  final String image;
  @override
  final String estimatedtime;

  factory CreateArticleModel.fromJson(Map<String, dynamic> json) {
    return CreateArticleModel(
        title: json["title"],
        subTitle: json['subTitile'],
        content: json['content'],
        tags: jsonDecode(json['tags']),
        image: json['image'],
        estimatedtime: json['estimatedReadTime']);
  }

  Map<String?, dynamic> toJson() {
    return {
      'title': title,
      'subTitle': subTitle,
      'content': content,
      'tags': tags,
      'image': image,
      'estimatedReadTime': estimatedtime
    };
  }

  @override
  List<Object?> get props => [];

  @override
  bool? get stringify => false;
}
