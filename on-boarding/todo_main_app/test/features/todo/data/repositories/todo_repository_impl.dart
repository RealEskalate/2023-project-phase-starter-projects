import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';
import 'package:todo_main_app/core/error/failure.dart' as core;

class MockTodoLocalDataSource extends Mock implements TodoLocalDataSource {}

void main() {
  late TodoRepositoryImpl repository;
  late MockTodoLocalDataSource mockLocalDataSource;

  setUp(() {
    mockLocalDataSource = MockTodoLocalDataSource();
    repository = TodoRepositoryImpl(mockLocalDataSource);
  });

  group('getAllTodos', () {
    test('should return a list of todos from local data source', () async {
      // Arrange
      final todos = [
        Todo(
            id: 1,
            title: 'Todo 1',
            description: 'Description 1',
            dueDate: DateTime.now()),
        Todo(
            id: 2,
            title: 'Todo 2',
            description: 'Description 2',
            dueDate: DateTime.now()),
      ];
      when(mockLocalDataSource.getAllTodos()).thenAnswer((_) async => todos);

      // Act
      final result = await repository.getAllTodos();

      // Assert
      expect(result, Right(todos));
      verify(mockLocalDataSource.getAllTodos());
      verifyNoMoreInteractions(mockLocalDataSource);
    });
    test('should return a failure when local data source throws an exception',
        () async {
      // Arrange
      when(mockLocalDataSource.getAllTodos()).thenThrow(Exception());

      // Act
      final result = await repository.getAllTodos();

      // Assert
      expect(
          result,
          const Left(core.ServerFailure(
              "Failed to get all todos"))); // Use the import prefix here
      verify(mockLocalDataSource.getAllTodos());
      verifyNoMoreInteractions(mockLocalDataSource);
    });
  });

  group('createTodo', () {
    // Add test cases for the createTodo method
  });

  group('updateTodo', () {
    // Add test cases for the updateTodo method
  });
}
