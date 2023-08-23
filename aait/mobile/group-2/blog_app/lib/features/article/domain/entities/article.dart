import 'package:equatable/equatable.dart';

import '../../../user/domain/entities/user_data.dart';
import 'tag.dart';

class Article extends Equatable {
  final String id;
  final String title;
  final String subTitle;
  final String content;
  final DateTime date;
  final String photoUrl;
  final UserData author;
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
