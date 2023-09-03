import '../../domain/entities/user_data_entity.dart';

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

class DataModel extends Data {
  DataModel({
    required id,
    required fullName,
    required email,
    required password,
    required expertise,
    required bio,
    required createdAt,
    required image,
    required imageCloudinaryPublicId,
    required List articles,
  }) : super(
          bio: bio,
          fullName: fullName,
          email: email,
          password: password,
          expertise: expertise,
          createdAt: createdAt,
          image: image,
          imageCloudinaryPublicId: imageCloudinaryPublicId,
          id: id,
        );

  factory DataModel.fromJson(Map<String, dynamic> json) {
    return DataModel(
      id: json["id"],
      fullName: json["fullName"],
      email: json["email"],
      password: json["password"],
      expertise: json["expertise"],
      bio: json["bio"],
      createdAt: DateTime.parse(json["createdAt"]),
      image: json["image"] ?? "",
      imageCloudinaryPublicId: json["imageCloudinaryPublicId"] ?? "",
      articles: [],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      "_id": id,
      "fullName": fullName,
      "email": email,
      "password": password,
      "expertise": expertise,
      "bio": bio,
      "createdAt": createdAt.toIso8601String(),
      "image": image,
      "imageCloudinaryPublicId": imageCloudinaryPublicId,
    };
  }
}
