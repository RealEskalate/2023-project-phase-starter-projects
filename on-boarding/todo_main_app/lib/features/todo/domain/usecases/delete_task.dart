import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';

import '../repositories/todo_repository.dart';

class DeleteTask implements UseCase<void, int> {
  final TodoRepository repository;

  DeleteTask(this.repository);

  @override
  Future<Either<Failure, void>> call(int taskId) async {
    return await repository.deleteTask(taskId);
  }
}
