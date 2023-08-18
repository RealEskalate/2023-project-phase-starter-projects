import '../todo_event.dart';

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
