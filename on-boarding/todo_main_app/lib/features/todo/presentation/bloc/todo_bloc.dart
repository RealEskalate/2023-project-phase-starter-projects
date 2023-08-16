import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import './bloc.dart';

class TodoBloc extends Bloc<TodoEvent, TodoState> {
  final GetAllTask getAllTasks;

  TodoBloc({
    required this.getAllTasks,
  }) : super(InitialState()) {
    on<LoadAllTasksEvent>((event, emit) async {
      emit(LoadingState());
      final Either<Failure, List<Todo>> result = await getAllTasks(NoParams());
      emit(result.fold(
        (failure) => ErrorState(_mapFailureToMessage(failure)),
        (tasks) => LoadedAllTasksState(tasks),
      ));
    });
  }

  String _mapFailureToMessage(Failure failure) {
    return 'An error occurred';
  }
}
