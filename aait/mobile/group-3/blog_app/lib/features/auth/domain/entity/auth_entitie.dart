import 'package:equatable/equatable.dart';

class AuthEntitie extends Equatable {
  final String email, password;
  final String? fullName, bio, expertise;

  const AuthEntitie({
    required this.email,
    required this.password,
    this.fullName,
    this.bio,
    this.expertise,
  });

  @override
  List<Object?> get props => [email, password, fullName, bio, expertise];
}
