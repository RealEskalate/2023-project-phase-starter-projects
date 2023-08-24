import 'package:equatable/equatable.dart';

class SignUpUserEnity extends Equatable {
  final String fullName;
  final String email;
  final String password;
  final String expertise;
  final String bio;

  const SignUpUserEnity(
      {
      required this.fullName,
      required this.email,
      required this.password,
      required this.expertise,
      required this.bio,
});
  @override
  List<Object?> get props => [fullName, email, password, expertise,bio];
}