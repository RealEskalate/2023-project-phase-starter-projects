import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

import '../repositories/todo_repository.dart';

class CreateTask implements UseCase<Either<Failure, Todo>, CreateTaskParams> {
  final TodoRepository repository;

  CreateTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(CreateTaskParams params) async {
    return await repository.createTask(params.task);
  }
}

class CreateTaskParams {
  final Todo task;

  CreateTaskParams({required this.task});
}
