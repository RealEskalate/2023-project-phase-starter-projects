import 'package:equatable/equatable.dart';

import '../../domain/entities/user_entity.dart';

class UserModel extends User implements Equatable {
  UserModel(
      {required this.id,
      required this.fullName,
      required this.email,
      this.expertise,
      this.bio,
      this.image})
      : super(
            id: id,
            fullName: fullName,
            email: email,
            expertise: expertise,
            bio: bio,
            image: image);

  final String id;
  final String fullName;
  final String email;
  final String? expertise;
  final String? bio;
  final String? image;

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
        id: json['id'],
        fullName: json['fullName'],
        email: json['email'],
        expertise: json['expertise'],
        bio: json['bio'],
        image: json['image']);
  }

  Map<String?, dynamic> toJson(UserModel userModel) {
    return {
      id: userModel.id,
      fullName: userModel.fullName,
      email: userModel.email,
      expertise: userModel.expertise,
      bio: userModel.bio,
      image: userModel.image
    };
  }

  @override
  List<Object?> get props => [id];

  @override
  bool? get stringify => false;
}
