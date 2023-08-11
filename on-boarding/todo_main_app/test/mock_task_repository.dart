import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/features/todo/domain/entities/task_list.dart';
import 'package:todo_main_app/features/todo/domain/repositories/task_repository.dart';
import 'package:todo_main_app/features/todo/domain/usecases/view_all_tasks_usecase.dart';
import 'package:todo_main_app/core/usecases/usescases.dart';

class MockTaskRepository extends Mock implements TaskRepository {
  @override
  Future<List<Task>> getAllTasks() async {
    return [
      Task(
          id: 1,
          title: 'Mock Task 1',
          description: "Mock 1 description",
          dueDate: DateTime.now(),
          isCompleted: false),
      Task(
          id: 2,
          title: 'Mock Task 2',
          description: "Mock 2 description",
          dueDate: DateTime.now(),
          isCompleted: false),
    ];
  }
}

void main() {
  late MockTaskRepository mockRepository;
  late ViewAllTasksUsecase usecase;

  setUp(() {
    mockRepository = MockTaskRepository();
    usecase = ViewAllTasksUsecase(mockRepository);
  });

  test('ViewAllTasks returns tasks from repository', () async {
    // Arrange
    final tasks = [
      Task(
        id: 1,
        title: 'Mock Task 1',
        description: "Mock 1 description",
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
      Task(
        id: 2,
        title: 'Mock Task 2',
        description: "Mock 2 description",
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
    ];

    // Mock the repository's getAllTasks() method behavior
    when(mockRepository.getAllTasks()).thenAnswer((_) async => tasks);

    // Act
    final result = await usecase(NoParams());

    // Assert
    expect(result, tasks);
  });
}
