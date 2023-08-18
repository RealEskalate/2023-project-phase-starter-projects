import 'package:todo_main_app/features/todo/presentation/bloc/todo_state.dart';

import '../../../domain/entities/todo.dart';

class LoadedAllTasksState extends TodoState {
  final List<Todo> tasks;

  const LoadedAllTasksState(this.tasks);

  @override
  List<Object> get props => [tasks];
}
