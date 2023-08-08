import 'package:todo_main_app/core/usecases/usescases.dart';
import 'package:todo_main_app/feature/task_list/domain/entities/task_list.dart';
import 'package:todo_main_app/feature/task_list/domain/repositories/task_repository.dart';

class ViewAllTasksUsecase implements UseCase<List<Task>, NoParams> {
  final TaskRepository repository;

  ViewAllTasksUsecase(this.repository);

  @override
  Future<List<Task>> call(NoParams params) async {
    return await repository.getAllTasks();
  }
}
