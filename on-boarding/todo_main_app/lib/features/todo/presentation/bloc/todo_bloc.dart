import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/create_task.dart';
import 'package:todo_main_app/core/usecases/get_all_tasks.dart';
import 'package:todo_main_app/core/usecases/get_single_task.dart';
import 'package:todo_main_app/core/usecases/update_task.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/task_list.dart';
import '../../../../core/usecases/delete_task.dart';

part 'todo_event.dart';
part 'todo_state.dart';

class TodoBloc extends Bloc<TodoEvent, TodoState> {
  final GetTodosUseCase getAllTasks;
  final GetSingleTask getSingleTask;
  final UpdateTask updateTask;
  final DeleteTask deleteTask;
  final CreateTask createTask;

  TodoBloc({
    required this.getAllTasks,
    required this.getSingleTask,
    required this.updateTask,
    required this.deleteTask,
    required this.createTask,
  }) : super(InitialState());

  Stream<TodoState> mapEventToState(
    TodoEvent event,
  ) async* {
    if (event is LoadAllTasksEvent) {
      yield LoadingState();
      final result = await getAllTasks(NoParams());
      yield result.fold(
        (failure) => ErrorState(_mapFailureToMessage(failure)),
        (tasks) => LoadedAllTasksState(tasks.cast<Task>()),
      );
    }
    // Implement handling of other events here...
  }

  String _mapFailureToMessage(Failure failure) {
    // Implement error message mapping logic here based on different failure types
    return 'An error occurred';
  }
}
