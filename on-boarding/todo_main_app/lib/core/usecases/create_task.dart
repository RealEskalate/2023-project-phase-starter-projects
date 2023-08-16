import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';

class CreateTask implements UseCase<Either<Failure, Todo>, CreateTaskParams> {
  final TodoRepository repository;

  CreateTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(CreateTaskParams params) async {
    return await repository.createTask(params.task as Todo);
  }
}

class CreateTaskParams {
  final Task task;

  CreateTaskParams(this.task);
}
