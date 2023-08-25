import 'package:equatable/equatable.dart';

class LoginUserEnity extends Equatable {

  final String email;
  final String password;


  const LoginUserEnity(
      {
      required this.email,
      required this.password,
});
  @override
  List<Object?> get props => [email, password];
}