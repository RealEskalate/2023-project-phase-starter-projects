import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/task_list.dart';
import 'package:todo_main_app/features/todo/domain/repositories/task_repository.dart';

class CreateTaskUsecase implements UseCase<void, Task> {
  final TaskRepository repository;

  CreateTaskUsecase(this.repository);

  @override
  Future<void> call(Task newTask) async {
    await repository.createTask(newTask);
  }
}
