part of 'signup_bloc.dart';

sealed class SignupState extends Equatable {
  const SignupState();

  @override
  List<Object> get props => [];
}

final class SignupInitial extends SignupState {}

final class SignupLoadingState extends SignupState {}

final class SignupErrorState extends SignupState {
  final String errorStateMessage;
  const SignupErrorState({required this.errorStateMessage});
}

final class SignupSuccessState extends SignupState {}
