import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import 'package:todo_main_app/features/todo/domain/usecases/create_task.dart';

class MockTodoRepository extends Mock implements TodoRepository {}

void main() {
  late CreateTask usecase;
  late MockTodoRepository mockRepository;

  setUp(() {
    mockRepository = MockTodoRepository();
    usecase = CreateTask(mockRepository);
  });

  final testTodo = Todo(
    id: 1,
    title: 'Test Task',
    description: 'This is a test task',
    dueDate: DateTime.now(),
    isCompleted: false,
  );

  final params = CreateTaskParams(task: testTodo);

  test('should create a task from the repository', () async {
    // Arrange
    when(mockRepository.createTask(any as Todo))
        .thenAnswer((_) async => Right(testTodo));

    // Act
    final result = await usecase(params);

    // Assert
    expect(result, Right(testTodo));
    verify(mockRepository.createTask(testTodo));
    verifyNoMoreInteractions(mockRepository);
  });

  test('should return a failure when creating task fails', () async {
    // Arrange
    when(mockRepository.createTask(any as Todo))
        .thenAnswer((_) async => const Left(ServerFailure("Server Error")));

    // Act
    final result = await usecase(params);

    // Assert
    expect(result, const Left(ServerFailure("Server Error")));
    verify(mockRepository.createTask(testTodo));
    verifyNoMoreInteractions(mockRepository);
  });
}
