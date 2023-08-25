import 'package:equatable/equatable.dart';

class Failure extends Equatable {
  const Failure({required this.message, required this.statusCode});

  final String message;
  final int? statusCode;

  @override
  List<Object?> get props => [message];
}

class ServerFailure extends Failure {
  const ServerFailure({required super.message, required super.statusCode});
}

class InvalidInputFailure extends Failure {
  InvalidInputFailure({required super.message, required super.statusCode});
}

class CacheFailure extends Failure {
  const CacheFailure({required super.message, super.statusCode});
}

class NetworkConnectionFailure extends Failure {
  const NetworkConnectionFailure({required super.message, super.statusCode});
}

class EmailAndPasswordNotMatchFailure extends Failure {
  const EmailAndPasswordNotMatchFailure({required super.message, super.statusCode});
}
