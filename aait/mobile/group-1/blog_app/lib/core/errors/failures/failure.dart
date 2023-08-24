import 'package:equatable/equatable.dart';

abstract class Failure extends Equatable {
  final List properties;
  const Failure([this.properties = const <dynamic>[]]);

  @override
  List<Object> get props => [properties];
}

class ServerFailure extends Failure {
  final String message;
  ServerFailure({required this.message}) : super([message]);
}

class ConnectionFailure extends Failure {
  final String message;
  ConnectionFailure({required this.message}) : super([message]);
}

class DatabaseFailure extends Failure {
  final String message;
  DatabaseFailure({required this.message}) : super([message]);
}

class CacheFailure extends Failure {
  final String message;
  CacheFailure({required this.message}) : super([message]);
}

class LocationFailure extends Failure {
  final String message;
  LocationFailure({required this.message}) : super([message]);
}

class PermissionFailure extends Failure {
  final String message;
  PermissionFailure({required this.message}) : super([message]);
}
// aait.mobile.g1.Henok.auth