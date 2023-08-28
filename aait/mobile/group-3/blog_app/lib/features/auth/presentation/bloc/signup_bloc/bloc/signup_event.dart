part of 'signup_bloc.dart';

sealed class SignupEvent extends Equatable {
  final String email, password, fullName, bio, expertise;

  const SignupEvent({
    required this.email,
    required this.password,
    required this.fullName,
    required this.bio,
    required this.expertise,
  });

  @override
  List<Object> get props => [];
}

class SignUp extends SignupEvent {
  const SignUp({
    required super.email,
    required super.password,
    required super.fullName,
    required super.bio,
    required super.expertise,
  });
}
