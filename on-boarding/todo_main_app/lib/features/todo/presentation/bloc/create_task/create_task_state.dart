import 'package:todo_main_app/features/todo/presentation/bloc/todo_state.dart';

import '../../../domain/entities/todo.dart';

class CreateTasksState extends TodoState {
  final List<Todo> tasks;

  const CreateTasksState(this.tasks);

  @override
  List<Object> get props => [tasks];
}
