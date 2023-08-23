part of 'auth_bloc.dart';

@immutable
sealed class AuthEvent extends Equatable {}

class AuthLogin extends AuthEvent {
  final String email;
  final String password;

  AuthLogin(this.email, this.password);

  @override
  List<Object?> get props => [email, password];
}

class AuthRegister extends AuthEvent {
  final String email;
  final String password;

  AuthRegister(this.email, this.password);

  @override
  List<Object?> get props => [email, password];
}
