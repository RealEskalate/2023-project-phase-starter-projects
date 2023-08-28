import 'package:equatable/equatable.dart';

import '../../../domain/entities/login_user_entitiy.dart';

class LogInEvent extends Equatable {
  const LogInEvent();
  @override
  List<Object> get props => [];
}

class OnLogInButtonPressedEvent extends LogInEvent {
  final LoginUserEnity loginUserEnity;
  const OnLogInButtonPressedEvent({required this.loginUserEnity});
}
