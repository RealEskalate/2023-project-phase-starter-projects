part of 'todo_bloc.dart';

sealed class TodoEvent extends Equatable {
  const TodoEvent();

  @override
  List<Object> get props => [];
}

class LoadAllTasksEvent extends TodoEvent {}

class GetSingleTaskEvent extends TodoEvent {
  final int taskId;

  const GetSingleTaskEvent(this.taskId);

  @override
  List<Object> get props => [taskId];
}

class UpdateTaskEvent extends TodoEvent {
  final int taskId;
  final String updatedTitle;
  final String updatedDescription;
  final DateTime updatedDueDate;

  const UpdateTaskEvent({
    required this.taskId,
    required this.updatedTitle,
    required this.updatedDescription,
    required this.updatedDueDate,
  });

  @override
  List<Object> get props =>
      [taskId, updatedTitle, updatedDescription, updatedDueDate];
}

class DeleteTaskEvent extends TodoEvent {
  final int taskId;

  const DeleteTaskEvent(this.taskId);

  @override
  List<Object> get props => [taskId];
}

class CreateTaskEvent extends TodoEvent {
  final String title;
  final String description;
  final DateTime dueDate;

  const CreateTaskEvent({
    required this.title,
    required this.description,
    required this.dueDate,
  });

  @override
  List<Object> get props => [title, description, dueDate];
}
