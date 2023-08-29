part of 'auth_bloc.dart';

class AuthState extends Equatable {
  const AuthState();

  @override
  List<Object?> get props => [];
}

class AuthInitial extends AuthState {}

class Loading extends AuthState {}

class LoginSuccessState extends AuthState {
  final AuthenticationEntity authenticationEntity;

  const LoginSuccessState({required this.authenticationEntity});

  @override
  List<Object> get props => [authenticationEntity];
}

class SignUpSuccessState extends AuthState {
  final AuthenticatedUserInfo authenticatedUserInfo;

  const SignUpSuccessState({required this.authenticatedUserInfo});

  @override
  List<Object> get props => [authenticatedUserInfo];
}

class LogoutSuccessState extends AuthState {}

class AuthError extends AuthState {
  final String message;

  const AuthError({required this.message});

  @override
  List<Object> get props => [message];
}

class UserAuthState extends AuthState {
  final String? token;
  const UserAuthState(this.token);
  @override
  List<Object?> get props => [token];
}
