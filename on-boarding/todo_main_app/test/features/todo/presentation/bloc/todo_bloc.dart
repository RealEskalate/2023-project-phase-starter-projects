import 'package:flutter_test/flutter_test.dart';
import 'package:bloc_test/bloc_test.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/usecases/delete_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_single_task.dart';
import 'package:todo_main_app/features/todo/domain/usecases/update_task.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';

class MockGetAllTask extends Mock implements GetAllTask {}

class MockGetSingleTask extends Mock implements GetSingleTask {}

class MockUpdateTask extends Mock implements UpdateTask {}

class MockDeleteTask extends Mock implements DeleteTask {}

void main() {
  late TodoBloc todoBloc;
  late MockGetAllTask mockGetAllTask;
  late MockGetSingleTask mockGetSingleTask;
  late MockUpdateTask mockUpdateTask;
  late MockDeleteTask mockDeleteTask;

  setUp(() {
    mockGetAllTask = MockGetAllTask();
    mockGetSingleTask = MockGetSingleTask();
    mockUpdateTask = MockUpdateTask();
    mockDeleteTask = MockDeleteTask();

    todoBloc = TodoBloc(
      getAllTasks: mockGetAllTask,
      getSingleTask: mockGetSingleTask,
      updateTask: mockUpdateTask,
      deleteTask: mockDeleteTask,
    );
  });

  test('initial state should be InitialState', () {
    expect(todoBloc.state, InitialState());
  });

  group('LoadAllTasksEvent', () {
    final tasks = [
      Todo(
          id: 1,
          title: 'Task 1',
          description: "",
          dueDate: DateTime.now(),
          isCompleted: false),
      Todo(
          id: 2,
          title: 'Task 2',
          description: "",
          dueDate: DateTime.now(),
          isCompleted: false)
    ];

    blocTest<TodoBloc, TodoState>(
      'emits [LoadingState, LoadedAllTasksState] when successful',
      build: () => todoBloc,
      act: (bloc) {
        when(mockGetAllTask(NoParams())).thenAnswer((_) async => Right(tasks));
        bloc.add(const LoadAllTasksEvent());
      },
      expect: () => [LoadingState(), LoadedAllTasksState(tasks)],
    );

    blocTest<TodoBloc, TodoState>(
      'emits [LoadingState, ErrorState] when unsuccessful',
      build: () => todoBloc,
      act: (bloc) {
        when(mockGetAllTask(NoParams())).thenAnswer(
            (_) async => const Left(ServerFailure("An error occurred")));
        bloc.add(const LoadAllTasksEvent());
      },
      expect: () => [LoadingState(), const ErrorState('An error occurred')],
    );
  });

  group('GetSingleTaskEvent', () {
    const taskId = 1;
    final task = Todo(
        id: taskId,
        title: 'Task 1',
        description: "",
        dueDate: DateTime.now(),
        isCompleted: false);

    blocTest<TodoBloc, TodoState>(
      'emits [LoadingState, LoadedSingleTaskState] when successful',
      build: () => todoBloc,
      act: (bloc) {
        when(mockGetSingleTask(0)).thenAnswer((_) async => Right(task));
        bloc.add(const GetSingleTaskEvent(taskId));
      },
      expect: () => [LoadingState(), LoadedSingleTaskState(task)],
    );

    blocTest<TodoBloc, TodoState>(
      'emits [LoadingState, ErrorState] when unsuccessful',
      build: () => todoBloc,
      act: (bloc) {
        when(mockGetSingleTask(0)).thenAnswer(
            (_) async => const Left(ServerFailure("An error occurred")));
        bloc.add(const GetSingleTaskEvent(taskId));
      },
      expect: () => [LoadingState(), const ErrorState('An error occurred')],
    );
  });
}
