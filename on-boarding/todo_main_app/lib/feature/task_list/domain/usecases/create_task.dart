import 'package:todo_main_app/core/usecases/usescases.dart';
import 'package:todo_main_app/feature/task_list/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/task_list/domain/repositories/task_repository.dart';

class CreateTaskUsecase implements UseCase<void, Task> {
  final TaskRepository repository;

  CreateTaskUsecase(this.repository);

  @override
  Future<void> call(Task newTask) async {
    await repository.createTask(newTask);
  }
}
