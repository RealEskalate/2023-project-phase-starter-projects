import 'package:todo_main_app/feature/todo/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/todo/domain/repositories/task_repository.dart';

class TaskRepositoryImpl implements TaskRepository {
  @override
  Future<List<Task>> getAllTasks() async {
    List<Task> tasks = [];
    return tasks;
  }

  @override
  Future<Task> getTaskById(int taskId) async {
    Task task = Task(
      id: taskId,
      title: 'Sample Task',
      description: 'Sample description',
      dueDate: DateTime.now(),
      isCompleted: false,
    );
    return task;
  }

  @override
  Future<void> createTask(Task task) async {
    // Implement logic to create a new task and save it to the data source
  }

  // update task with isCOmpleted variable
  @override
  Future<void> updateTaskCompletionStatus(int taskId, bool isCompleted) async {
    // Implement logic to update the task completion status
  }
  @override
  Future<void> updateTask(Task task) async {
    // Implement logic to update the task
  }
}
