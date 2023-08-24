import '../../domain/entities/authenticated_user_info.dart';

class AuthenticatedUserInfoModel extends AuthenticatedUserInfo {
  const AuthenticatedUserInfoModel(
      {required super.fullName,
      required super.email,
      required super.expertise,
      required super.bio,
      required super.image,
      required super.imageCloudinaryPublicId});

  factory AuthenticatedUserInfoModel.fromJson(Map<String, dynamic> json) {
    return AuthenticatedUserInfoModel(
      fullName: json['fullName'],
      email: json['email'],
      expertise: json['expertise'],
      bio: json['bio'],
      image: json['image'],
      imageCloudinaryPublicId: json['imageCloudinaryPublicId'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'fullName': fullName,
      'email': email,
      'expertise': expertise,
      'bio': bio,
      'image': image,
      'imageCloudinaryPublicId': imageCloudinaryPublicId,
    };
  }
}
