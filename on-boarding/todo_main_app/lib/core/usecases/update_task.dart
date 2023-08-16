import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';

class UpdateTask implements UseCase<Either<Failure, Todo>, UpdateTaskParams> {
  final TodoRepository repository;

  UpdateTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(UpdateTaskParams params) async {
    return repository.updateTask(params.task as Todo);
  }
}

class UpdateTaskParams {
  final Task task;

  UpdateTaskParams(this.task);
}
