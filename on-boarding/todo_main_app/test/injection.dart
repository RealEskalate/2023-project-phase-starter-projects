import 'package:bloc_test/bloc_test.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/usecases/get_all_tasks.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';

class MockGetAllTask extends Mock implements GetAllTask {}

void main() {
  late MockGetAllTask mockGetAllTask;
  late TodoBloc todoBloc;

  setUp(() {
    mockGetAllTask = MockGetAllTask();
    todoBloc = TodoBloc(getAllTasks: mockGetAllTask);
  });

  tearDown(() {
    todoBloc.close();
  });

  final tTodoList = [
    Todo(
        id: 1,
        title: 'Task 1',
        description: 'Description 1',
        isCompleted: false,
        dueDate: DateTime.now()),
    Todo(
        id: 2,
        title: 'Task 2',
        description: 'Description 2',
        isCompleted: true,
        dueDate: DateTime.now()),
  ];

  test('initial state should be InitialState', () {
    expect(todoBloc.state, equals(InitialState()));
  });

  blocTest<TodoBloc, TodoState>(
    'should emit [LoadingState, LoadedAllTasksState] when LoadAllTasksEvent is added',
    build: () {
      when(mockGetAllTask(NoParams()))
          .thenAnswer((_) async => Right(tTodoList));
      return todoBloc;
    },
    act: (bloc) => bloc.add(const LoadAllTasksEvent()),
    expect: () => [
      LoadingState(),
      LoadedAllTasksState(tTodoList),
    ],
  );

  blocTest<TodoBloc, TodoState>(
    'should emit [LoadingState, ErrorState] when LoadAllTasksEvent fails',
    build: () {
      when(mockGetAllTask(NoParams())).thenAnswer(
          (_) async => const Left(ServerFailure("An error occurred")));
      return todoBloc;
    },
    act: (bloc) => bloc.add(const LoadAllTasksEvent()),
    expect: () => [
      LoadingState(),
      const ErrorState('An error occurred'),
    ],
  );
}
