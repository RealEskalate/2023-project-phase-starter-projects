class Article {
  final String id;
  final String title;
  final String subTitle;
  final String? user;
  final List<String> tags;
  final String content;
  final String? image;
  final String? estimatedtime;
  final String? imageCloudinaryPublicId;
  final DateTime? createdAt;

  Article(
      {required this.id,
      required this.title,
      required this.subTitle,
      required this.tags,
      this.user,
      required this.content,
      this.image,
      this.estimatedtime,
      this.imageCloudinaryPublicId,
      this.createdAt});
}
