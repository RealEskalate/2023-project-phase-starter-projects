import 'package:equatable/equatable.dart';

abstract class TodoState extends Equatable {
  const TodoState();

  @override
  List<Object> get props => [];
}

class InitialState extends TodoState {}

class LoadingState extends TodoState {}

class ErrorState extends TodoState {
  final String errorMessage;

  const ErrorState(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}

final class TodoInitial extends TodoState {}
