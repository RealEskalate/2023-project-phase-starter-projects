class CreateArticleEntity {
  final String? id;
  final String title;
  final String subTitle;
  final List<String> tags;
  final String content;
  final String? image;
  final String? estimatedtime;

  CreateArticleEntity(
      {this.id,
        required this.title,
      required this.subTitle,
      required this.tags,
      required this.content,
      this.image,
      this.estimatedtime});
}
