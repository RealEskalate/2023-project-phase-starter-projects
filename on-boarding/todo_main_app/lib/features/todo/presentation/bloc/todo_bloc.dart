import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/usecases/delete_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/update_task.dart';
import './bloc.dart';

class TodoBloc extends Bloc<TodoEvent, TodoState> {
  final GetAllTask getAllTasks;
  final GetSingleTask getSingleTask;
  final UpdateTask updateTask;
  final DeleteTask deleteTask;

  TodoBloc({
    required this.getAllTasks,
    required this.getSingleTask,
    required this.updateTask,
    required this.deleteTask,
  }) : super(InitialState()) {
    on<LoadAllTasksEvent>((event, emit) async {
      emit(LoadingState());
      final Either<Failure, List<Todo>> result = await getAllTasks(NoParams());
      emit(result.fold(
        (failure) => ErrorState(_mapFailureToMessage(failure)),
        (tasks) => LoadedAllTasksState(tasks),
      ));
    });

    on<GetSingleTaskEvent>((event, emit) async {
      emit(LoadingState());
      final Either<Failure, Todo> result = await getSingleTask(event.taskId);
      emit(result.fold(
        (failure) => ErrorState(_mapFailureToMessage(failure)),
        (task) => LoadedSingleTaskState(task),
      ));
    });
    on<UpdateTaskEvent>((event, emit) async {
      emit(LoadingState());
      final updatedTask = Todo(
        id: event.taskId,
        title: event.updatedTitle,
        description: event.updatedDescription,
        dueDate: event.updatedDueDate,
        isCompleted: true, // Mark task as completed
      );

      final Either<Failure, Todo> result =
          await updateTask(UpdateTaskParams(task: updatedTask));
      emit(result.fold(
        (failure) => ErrorState(_mapFailureToMessage(failure)),
        (task) => LoadedSingleTaskState(task),
      ));
    });

    on<DeleteTaskEvent>((event, emit) async {
      emit(LoadingState());
      final result = await deleteTask(event.taskId);
      result.fold(
        (failure) => emit(ErrorState(_mapFailureToMessage(failure))),
        (_) => emit(
            DeletedTaskState()), // You might want to define a DeletedTaskState
      );
    });
  }

  String _mapFailureToMessage(Failure failure) {
    return 'An error occurred';
  }
}
