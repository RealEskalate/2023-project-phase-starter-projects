

import '../../domain/entity/auth_entitie.dart';

class AuthEntitieModel extends AuthEntitie {
  final String email, password;
  final String? fullName, bio, expertise;

  const AuthEntitieModel({
    required this.email,
    required this.password,
    this.fullName,
    this.bio,
    this.expertise,
  }) : super(email: email, password: password);

  factory AuthEntitieModel.fromJson(Map<String, dynamic> json) {
    return AuthEntitieModel(
      email: json['emial'],
      password: json['password'],
      fullName: json['fullName'],
      bio: json['bio'],
      expertise: json['expertise'],
    );
  }

  Map<String, dynamic> toJsonSignup() {
    return {
      'email': email,
      'password': password,
      'fullName': fullName,
      'bio': bio,
      'expertise': expertise,
    };
  }

  Map<String, dynamic> toJsonLogin() {
    return {
      'email': email,
      'password': password,
    };
  }
}
