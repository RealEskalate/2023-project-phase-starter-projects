import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';

import '../entities/todo.dart';
import '../repositories/todo_repository.dart';

class GetSingleTask implements UseCase<Either<Failure, Todo>, int> {
  final TodoRepository repository;

  GetSingleTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(int taskId) async {
    return repository.getSingleTask(taskId);
  }
}
