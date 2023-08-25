import 'package:equatable/equatable.dart';

abstract class Failure extends Equatable {
  const Failure();

  @override
  List<Object> get props => [];
}

class ServerFailure extends Failure {}

class CacheFailure extends Failure {}

class NetworkFailure extends Failure {}

class LoginFailure extends Failure {}

class SignUpFailure extends Failure {}

class LogoutFailure extends Failure {}
