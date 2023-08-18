import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';

import '../entities/todo.dart';
import '../repositories/todo_repository.dart';

class UpdateTask implements UseCase<Either<Failure, Todo>, UpdateTaskParams> {
  final TodoRepository repository;

  UpdateTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(UpdateTaskParams params) async {
    return await repository.updateTask(params.task);
  }
}

class UpdateTaskParams {
  final Todo task;

  UpdateTaskParams({required this.task});
}
