class Article {
  final String id;
  final List<String> tags;
  final String content;
  final String title;
  final String subTitle;
  final String estimatedReadTime;
  final String user;
  final String image;
  final String imageCloudinaryPublicId;
  final DateTime createdAt;

  Article({
    required this.id,
    required this.tags,
    required this.content,
    required this.title,
    required this.subTitle,
    required this.estimatedReadTime,
    required this.user,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.createdAt,
  });
}
