import 'package:equatable/equatable.dart';

class AuthenticatedUserInfo extends Equatable {
  final String fullName;
  final String email;

  final String expertise;
  final String bio;

  final String? image;
  final String? imageCloudinaryPublicId;

  const AuthenticatedUserInfo({
    required this.fullName,
    required this.email,
    required this.expertise,
    required this.bio,
    this.image,
    this.imageCloudinaryPublicId,
  });

  @override
  List<Object?> get props =>
      [fullName, email, expertise, bio, image, imageCloudinaryPublicId];
}
