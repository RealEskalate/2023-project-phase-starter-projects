import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/core/usecases/get_todos_usecase.dart';
import 'package:todo_main_app/core/usecases/usescases.dart';

class MockTodoRepository implements TodoRepository {
  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    // Return a list of sample todos for testing
    return Right([
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
    ]);
  }
}

void main() {
  late GetTodosUseCase useCase;
  late MockTodoRepository repository;

  setUp(() {
    repository = MockTodoRepository();
    useCase = GetTodosUseCase(repository);
  });

  test('should get a list of todos from the repository', () async {
    final result = await useCase(NoParams());

    // Check if the result is a Right (successful) value
    expect(result, isA<Right<Failure, List<Todo>>>());

    // Get the actual value from the Right
    final todos = result.getOrElse(() => throw Exception());

    // Verify the length of the list
    expect(todos.length, 2);
  });
}
