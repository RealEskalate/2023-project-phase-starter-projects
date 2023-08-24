class User {
  final String id;
  final String fullName;
  final String email;
  final String expertise;
  final String bio;
  final String image;
  final String imageCloudinaryPublicId;
  final DateTime createdAt;

  User({
    required this.id,
    required this.fullName,
    required this.email,
    required this.expertise,
    required this.bio,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.createdAt,
  });
}
