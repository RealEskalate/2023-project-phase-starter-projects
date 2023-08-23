import 'package:equatable/equatable.dart';

class LoginRequestEntity extends Equatable {
  final String email;
  final String password;

  const LoginRequestEntity({required this.email, required this.password});

  @override
  List<Object?> get props => [email, password];
}
