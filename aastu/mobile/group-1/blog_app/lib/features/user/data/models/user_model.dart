class UserModel {
  final String id;
  final String fullName;
  final String email;
  final String expertise;
  final String bio;
  final String image;
  final String imageCloudinaryPublicId;
  final DateTime createdAt;

  UserModel({
    required this.id,
    required this.fullName,
    required this.email,
    required this.expertise,
    required this.bio,
    required this.image,
    required this.imageCloudinaryPublicId,
    required this.createdAt,
  });

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      id: json['_id'],
      fullName: json['fullName'],
      email: json['email'],
      expertise: json['expertise'],
      bio: json['bio'],
      image: json['image'],
      imageCloudinaryPublicId: json['imageCloudinaryPublicId'],
      createdAt: DateTime.parse(json['createdAt']),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'fullName': fullName,
      'email': email,
      'expertise': expertise,
      'bio': bio,
    };
  }
}
