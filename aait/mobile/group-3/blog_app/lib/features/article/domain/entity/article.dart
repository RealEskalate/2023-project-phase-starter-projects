import 'package:equatable/equatable.dart';

import 'user.dart';

class Article extends Equatable {
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final User user;
  final String image;
  final String imageCloudinaryPublicId;
  final DateTime createdAt;
  final String id;

  const Article({
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.user,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.createdAt,
    required this.id,
  });

  Article.empty()
      : this(
          tags: ['_empty.tags'],
          content: '_empty.content',
          title: '_empty.title',
          subTitle: '_empty.subTitle',
          estimatedReadTime: '_empty.estimatedReadTime',
          user: User.empty(),
          image: '_empty.image',
          imageCloudinaryPublicId: '_empty.imageCludinaryPublicId',
          createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
          id: '1',
        );

  @override
  List<Object?> get props => [id];
}
