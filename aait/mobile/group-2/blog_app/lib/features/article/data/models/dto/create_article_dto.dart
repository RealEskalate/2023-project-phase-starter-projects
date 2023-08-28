import 'dart:io';

class CreateUpdateArticleDto {
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final String photoPath;
  final List<String> tags;
  final String content;

  CreateUpdateArticleDto(
      {required this.title,
      required this.subTitle,
      required this.estimatedReadTime,
      required this.photoPath,
      required this.tags,
      required this.content});

  Map<String, dynamic> toJson() => {
        'title': title,
        'subTitle': subTitle,
        'content': content,
        'estimatedReadTime': estimatedReadTime,
        'photo': File(photoPath),
        'tags': tags
      };
}
