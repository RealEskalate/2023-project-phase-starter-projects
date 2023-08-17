import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

class MockTodoLocalDataSource extends Mock implements TodoLocalDataSource {}

void main() {
  late TodoRepositoryImpl repository;
  late MockTodoLocalDataSource mockLocalDataSource;

  setUp(() {
    mockLocalDataSource = MockTodoLocalDataSource();
    repository = TodoRepositoryImpl(mockLocalDataSource);
  });

  group('getAllTodos', () {
    test('should return a list of todos from the local data source', () async {
      final todos = [
        Todo(
            id: 1,
            title: 'Task 1',
            description: 'Description 1',
            dueDate: DateTime.now(),
            isCompleted: false),
        Todo(
            id: 2,
            title: 'Task 2',
            description: 'Description 2',
            dueDate: DateTime.now(),
            isCompleted: false),
      ];
      when(mockLocalDataSource.getAllTodos()).thenAnswer((_) async => todos);

      final result = await repository.getAllTodos();

      expect(result, equals(Right(todos)));
      verify(mockLocalDataSource.getAllTodos());
      verifyNoMoreInteractions(mockLocalDataSource);
    });

    test(
        'should return a failure when the local data source throws an exception',
        () async {
      when(mockLocalDataSource.getAllTodos()).thenThrow(Exception());

      final result = await repository.getAllTodos();

      expect(
          result, equals(const Left(ServerFailure("Failed to get all todos"))));
      verify(mockLocalDataSource.getAllTodos());
      verifyNoMoreInteractions(mockLocalDataSource);
    });
  });

  // Add similar test cases for other repository methods
}
