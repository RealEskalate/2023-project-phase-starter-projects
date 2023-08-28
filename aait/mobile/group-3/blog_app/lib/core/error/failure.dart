import 'package:equatable/equatable.dart';

import 'exception.dart';

class Failure extends Equatable {
  const Failure({required this.message, required this.statusCode});

  final String message;
  final int statusCode;

  String get errorMessage => '$statusCode Error: $message';

  @override
  List<Object> get props => [message, statusCode];
}

class ServerFailure extends Failure {
  const ServerFailure({required super.message, required super.statusCode});
  ServerFailure.fromException(ServerException exception)
   :this(message: exception.message, statusCode: exception.statusCode);
}

class InvalidInputFailure extends Failure {
  InvalidInputFailure({required super.message, required super.statusCode});
}

class CacheFailure extends Failure {
  const CacheFailure({required super.message, required super.statusCode});
}

class NetworkConnectionFailure extends Failure {
  const NetworkConnectionFailure({required super.message, required super.statusCode});
}

class EmailAndPasswordNotMatchFailure extends Failure {
  const EmailAndPasswordNotMatchFailure({required super.message, required super.statusCode});
}
