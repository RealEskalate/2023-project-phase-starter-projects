import '../todo_event.dart';

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
