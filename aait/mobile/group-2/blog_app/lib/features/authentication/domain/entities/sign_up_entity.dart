import 'package:equatable/equatable.dart';

class SignUpEntity extends Equatable {
  final String email;
  final String password;
  final String fullName;
  final String bio;
  final String expertise;

  const SignUpEntity({
    required this.email,
    required this.password,
    required this.fullName,
    required this.bio,
    required this.expertise,
  });

  @override
  List<Object?> get props => [email, password, fullName, bio, expertise];
}
