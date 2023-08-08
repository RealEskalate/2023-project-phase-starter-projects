import 'package:todo_main_app/feature/task_list/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/task_list/domain/repositories/task_repository.dart';

class TaskRepositoryImpl implements TaskRepository {
  @override
  Future<List<Task>> getAllTasks() async {
    List<Task> tasks = [
      Task(
        id: 0,
        title: 'Todo App UI Design',
        description:
            'Design a UI/UX for mobile app. We can use figma or Adobe for designing the UI.',
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
      Task(
        id: 1,
        title: 'Attending Study Session',
        description: 'Attend the study session at 8:00 PM.',
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
      Task(
        id: 2,
        title: 'View Candidates',
        description:
            'View the candidates for the job opening and then shortlist them.',
        dueDate: DateTime.now(),
        isCompleted: false,
      ),
      Task(
        id: 3,
        title: 'Football Match',
        description: 'Watching the football match at 9:00 PM with friends.',
        dueDate: DateTime.now(),
        isCompleted: true,
      ),
    ];
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
