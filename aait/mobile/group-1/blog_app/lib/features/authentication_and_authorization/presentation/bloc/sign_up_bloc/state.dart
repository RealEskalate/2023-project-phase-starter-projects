import 'package:equatable/equatable.dart';

import '../../../domain/entities/sign_up_user_entity.dart';

class SignUpState extends Equatable {
  const SignUpState();
  @override
  List<Object> get props => [];
}

class SignupInitState extends SignUpState {}

class SignupLoadingState extends SignUpState {}

class SignUpLoadedState extends SignUpState {
  final SignUpUserEnity signUpUserEnity;
  const SignUpLoadedState({required this.signUpUserEnity});
  @override
  List<Object> get props => [signUpUserEnity];
}

class SignupErrorState extends SignUpState {
  final String message;
  const SignupErrorState({required this.message});
  @override
  List<Object> get props => [message];
}
