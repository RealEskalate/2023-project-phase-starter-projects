import 'package:equatable/equatable.dart';

class SignUpUserEnity extends Equatable {
  final String id;
  final String fullName;
  final String email;
  final String password;
  final String expertise;
  final String bio;
  final String image;

  const SignUpUserEnity(
      {required this.id,
      required this.fullName,
      required this.email,
      required this.password,
      required this.expertise,
      required this.bio,
      required this.image});
  @override
  List<Object?> get props => [id, fullName, email, password, expertise,bio,image];
}