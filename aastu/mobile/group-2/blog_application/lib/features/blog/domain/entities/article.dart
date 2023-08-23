import 'package:blog_application/features/blog/domain/entities/user.dart';
import 'package:equatable/equatable.dart';

class Article extends Equatable {
  Article({
    required this.id,
    required this.title,
    required this.content,
    required this.tags,
    this.createdAt,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.image,
    this.user
  });

  final String id;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final String image;
  final User? user;
  final String content;
  final List<String> tags;
  final DateTime? createdAt;

  @override
  List<Object?> get props => [id, title, content, tags, createdAt, subTitle, estimatedReadTime, image, user];
}