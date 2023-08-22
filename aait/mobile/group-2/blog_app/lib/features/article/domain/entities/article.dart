import 'tag.dart';

class Article {
  final String id;
  final String title;
  final String subTitle;
  final String content;
  final String date;
  final String photo;
  final String author;
  final List<Tag> tags;
  final String estimatedReadTime;

  const Article({
    required this.id,
    required this.title,
    required this.subTitle,
    required this.content,
    required this.date,
    required this.photo,
    required this.author,
    required this.tags,
    required this.estimatedReadTime,
  });
}
