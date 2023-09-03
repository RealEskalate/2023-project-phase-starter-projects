import '../../domain/entity/user.dart';

class UserModel extends User {
  const UserModel({
    required super.fullName,
    required super.email,
    required super.expertise,
    required super.bio,
    required super.createdAt,
    required super.image,
    required super.imageCloudinaryPublicId,
    required super.id,
  });

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      fullName: json['fullName'] ?? "No Name",
      email: json['email'] ?? "No Email",
      expertise: json['expertise'] ?? "No Expertise",
      bio: json['bio'] ?? "No Bio",
      createdAt: _dateTimeFromJson(json['createdAt']),
      image: json['image'] ?? "assts/images/profpic.jpg",
      imageCloudinaryPublicId:
          json['imageCloudinaryPublicId'] ?? "No imageCloudinaryPublicId",
      id: json['id'] ?? "No Id",
    );
  }


  static DateTime _dateTimeFromJson(dynamic json) {
    try {
      if (json is String) {
        return DateTime.parse(json);
      } else {
        return DateTime.now();
      }
    } catch (e) {
      return DateTime.now();
    }
  }

  UserModel.empty()
      : this(
          fullName: "Tamirat Dereje",
          email: "tamiratdereje@gmail.com",
          expertise: "designer",
          bio: "I am passionate designer who see beauty in everything",
          createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
          image:
              "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
          imageCloudinaryPublicId: "guf4tul1ftar9hdpnaev",
          id: "64e25674bfc65d390e781205",
        );
}
