// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'package:equatable/equatable.dart';

class CacheException extends Equatable implements Exception {
  final String message;

  const CacheException({this.message = 'Cache Exception'});

  @override
  List<Object> get props => [message];
}

class ServerException extends Equatable implements Exception {
  final String message;

  const ServerException({this.message = 'Server Exception'});

  @override
  List<Object> get props => [message];
}

class NetworkException extends Equatable implements Exception {
  final String message;

  const NetworkException({this.message = 'Network Exception'});

  @override
  List<Object> get props => [message];
}

class LoginException extends Equatable implements Exception {
  final String message;
  const LoginException({
    required this.message,
  });

  @override
  List<Object?> get props => [message];
}

class SignUpException extends Equatable implements Exception {
  final String message;
  const SignUpException({
    required this.message,
  });

  @override
  List<Object?> get props => [message];
}

class LogoutException extends Equatable implements Exception {
  final String message;
  const LogoutException({
    required this.message,
  });
  @override
  List<Object?> get props => [message];
}
