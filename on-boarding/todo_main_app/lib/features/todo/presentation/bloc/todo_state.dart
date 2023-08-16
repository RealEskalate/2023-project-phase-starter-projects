
part of 'todo_bloc.dart';

sealed class TodoState extends Equatable {
  const TodoState();
  
  @override
  List<Object> get props => [];
}

class InitialState extends TodoState {}

class LoadingState extends TodoState {}

class LoadedAllTasksState extends TodoState {
  final List<Task> tasks;

  const LoadedAllTasksState(this.tasks);

  @override
  List<Object> get props => [tasks];
}

class LoadedSingleTaskState extends TodoState {
  final Task task;

  const LoadedSingleTaskState(this.task);

  @override
  List<Object> get props => [task];
}

class ErrorState extends TodoState {
  final String errorMessage;

  const ErrorState(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}



final class TodoInitial extends TodoState {}

