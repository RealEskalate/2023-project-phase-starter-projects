import 'package:equatable/equatable.dart';

import '../../../domain/entities/sign_up_user_entity.dart';

class SignUpEvent extends Equatable {
  const SignUpEvent();
  @override
  List<Object> get props => [];
}

class OnSignUpButtonPressedEvent extends SignUpEvent {
  final SignUpUserEnity signUpUserEnity;

  const OnSignUpButtonPressedEvent({required this.signUpUserEnity});
}
