part of 'auth_bloc.dart';

@immutable
abstract class AuthState extends Equatable {}

final class AuthInitial extends AuthState {
  @override
  List<Object?> get props => throw UnimplementedError();
}

class AuthLoading extends AuthState {
  @override
  List<Object?> get props => throw UnimplementedError();
}

class AuthFailed extends AuthState {
  final String error;
  AuthFailed(this.error);

  @override
  List<Object?> get props => [error];
}

class AuthPass extends AuthState {
  @override
  List<Object?> get props => throw UnimplementedError();
}
