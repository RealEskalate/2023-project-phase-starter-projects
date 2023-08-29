part of 'auth_bloc.dart';

class AuthEvent extends Equatable {
  const AuthEvent();

  @override
  List<Object> get props => [];
}

class LoginEvent extends AuthEvent {
  final LoginRequestEntity loginRequestEntity;

  const LoginEvent({required this.loginRequestEntity});
}

class SignUpEvent extends AuthEvent {
  final SignUpEntity signUpRequest;

  const SignUpEvent(this.signUpRequest);
}

class LogoutEvent extends AuthEvent {}

class GetTokenEvent extends AuthEvent {}
