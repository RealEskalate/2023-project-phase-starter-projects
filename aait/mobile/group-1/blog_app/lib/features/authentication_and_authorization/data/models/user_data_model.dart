import 'package:blog_app/features/authentication_and_authorization/domain/entities/user_data_entity.dart';

class UserDataModel extends UserDataEntity {


  UserDataModel({
    required data,
    required token,
  }) : super(data: data, token: token);

  factory UserDataModel.fromJson(Map<String, dynamic> json) {
    return UserDataModel(
      data: json["data"],
      token: json["token"],
    );
  }
}

class Data {
  String id;
  String fullName;
  String email;
  String password;
  String expertise;
  String bio;
  DateTime createdAt;
  int v;
  String image;
  String imageCloudinaryPublicId;

  Data({
    required this.id,
    required this.fullName,
    required this.email,
    required this.password,
    required this.expertise,
    required this.bio,
    required this.createdAt,
    required this.v,
    required this.image,
    required this.imageCloudinaryPublicId,
  });

  factory Data.fromJson(Map<String, dynamic> json) {
    return Data(
      id: json["_id"],
      fullName: json["fullName"],
      email: json["email"],
      password: json["password"],
      expertise: json["expertise"],
      bio: json["bio"],
      createdAt: DateTime.parse(json["createdAt"]),
      v: json["__v"],
      image: json["image"],
      imageCloudinaryPublicId: json["imageCloudinaryPublicId"],
    );
  }
}
