import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';

class GetSingleTask implements UseCase<Either<Failure, Todo>, int> {
  final TodoRepository repository;

  GetSingleTask(this.repository);

  @override
  Future<Either<Failure, Todo>> call(int taskId) async {
    return repository.getSingleTask(taskId);
  }
}
