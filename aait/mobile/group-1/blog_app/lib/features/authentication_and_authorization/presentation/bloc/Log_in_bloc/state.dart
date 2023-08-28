import 'package:equatable/equatable.dart';

import '../../../domain/entities/user_data_entity.dart';

class LoginState extends Equatable {
  const LoginState();
  @override
  List<Object> get props => [];
}

class LoginInitState extends LoginState {}

class LoginLoadingState extends LoginState {}

class LoginLoadedState extends LoginState {
  final UserDataEntity loginUserEnity;

  const LoginLoadedState({required this.loginUserEnity});
  @override
  List<Object> get props => [loginUserEnity];
}

class ErrorState extends LoginState {
  final String message;
  const ErrorState({required this.message});
  @override
  List<Object> get props => [message];
}
