import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import '../../../../core/error/failure.dart';
import '../entities/todo.dart';
import '../repositories/todo_repository.dart';

class GetAllTask implements UseCase<Either<Failure, List<Todo>>, NoParams> {
  late final TodoRepository repository;

  GetAllTask(this.repository); // Pass the repository through constructor

  @override
  Future<Either<Failure, List<Todo>>> call(NoParams params) async {
    return await repository.getAllTodos();
  }
}
