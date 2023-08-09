import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';

class MockTodoRepository implements TodoRepository {
  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    // Return a list of sample todos for testing
    final todos = [
      Todo(
          id: 1,
          title: 'Todo 1',
          description: 'Description 1',
          dueDate: DateTime.now(),
          isCompleted: false),
      Todo(
          id: 2,
          title: 'Todo 2',
          description: 'Description 2',
          dueDate: DateTime.now(),
          isCompleted: true),
    ];

    // Return Right with the list of todos
    return Right(todos);
  }
}
