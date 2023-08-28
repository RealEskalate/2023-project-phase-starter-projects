part of 'auth_bloc_bloc.dart';

sealed class AuthBlocEvent extends Equatable {
  const AuthBlocEvent();

  @override
  List<Object> get props => [];
}


class AppStarted extends AuthBlocEvent{
  String toString() => 'AppStarted';
}

class LoggedIn extends AuthBlocEvent{
  final String token;

  LoggedIn({required this.token});

  @override
  String toString() => 'Loggedin {token : $token}';
}

class LoggedOut extends AuthBlocEvent{
  @override
  String toString() => 'LoggedOut';
}