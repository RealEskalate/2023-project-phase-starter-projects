import 'package:blog_app/features/authentication_and_authorization/domain/entities/user_data_entity.dart';
import 'package:equatable/equatable.dart';

import 'tag.dart';

class Article extends Equatable {
  final String id;
  final String title;
  final String subTitle;
  final String content;
  final DateTime date;
  final String photoUrl;
  final Data author;
  final List<Tag> tags;
  final String estimatedReadTime;

  const Article({
    required this.id,
    required this.title,
    required this.subTitle,
    required this.content,
    required this.date,
    required this.photoUrl,
    required this.author,
    required this.tags,
    required this.estimatedReadTime,
  });

  @override
  List<Object?> get props => [
        id,
        title,
        subTitle,
        content,
        date,
        photoUrl,
        author,
        tags,
        estimatedReadTime
      ];
}
