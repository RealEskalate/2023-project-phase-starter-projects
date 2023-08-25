part of 'login_bloc.dart';

sealed class LoginState extends Equatable {
  const LoginState();

  @override
  List<Object> get props => [];
}

final class LoginInitial extends LoginState {}

final class LoginLoadingState extends LoginState {}

final class LoginErrorState extends LoginState {
  final String errorStateMessage;
  const LoginErrorState({required this.errorStateMessage});
  
}

final class LoginSuccessState extends LoginState {}
