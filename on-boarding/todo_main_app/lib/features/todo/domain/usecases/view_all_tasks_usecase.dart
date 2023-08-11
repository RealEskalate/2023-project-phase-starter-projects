import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescases.dart';
import 'package:todo_main_app/features/todo/domain/repositories/task_repository.dart';

import 'package:dartz/dartz.dart'; // Import the Either class

class ViewAllTasksUsecase
    implements UseCase<Either<Failure, List<Task>>, NoParams> {
  final TaskRepository repository;

  ViewAllTasksUsecase(this.repository);

  @override
  Future<Either<Failure, List<Task>>> call(NoParams params) async {
    // try {
    //   final tasks = await repository.getAllTasks();
    //   return Right(tasks.cast<Task>());
    // } catch (e) {
    //   return Left(Failure("Failed to load tasks")); // Create a Failure object
    // }
    return const Right([]);
  }
}
