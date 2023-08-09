import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/feature/todo/data/repositories/todo_repository_impl.dart';

class MockTodoRepository implements TodoRepository {
  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    final todos = [
      Todo(
        id: 1,
        title: 'Todo 1',
        description: 'Description 1',
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
      Todo(
        id: 2,
        title: 'Todo 2',
        description: 'Description 2',
        dueDate: DateTime.now(),
        isCompleted: true,
      ),
    ];

    return Right(todos);
  }
}

void main() {
  late TodoRepositoryImpl repository;

  setUp(() {
    repository = TodoRepositoryImpl();
  });

  test('should get a list of todos from the repository', () async {
    final result = await repository.getAllTodos();

    // Verify that the result is a Right containing a list of todos
    expect(result, isA<Right<Failure, List<Todo>>>());

    // Extract the todos from the Right
    final todos = result.getOrElse(() => throw Exception());

    // Verify that the list of todos has the expected length
    expect(todos.length, 2);

    // Verify the properties of the first todo
    expect(todos[0].id, 1);
    expect(todos[0].title, 'Todo 1');
    expect(todos[0].isCompleted, false);

    // Verify the properties of the second todo
    expect(todos[1].id, 2);
    expect(todos[1].title, 'Todo 2');
    expect(todos[1].isCompleted, true);
  });
}
