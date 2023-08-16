import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/usecases/usescase.dart';
import 'package:todo_main_app/features/todo/data/repositories/todo_repository_impl.dart';

import '../entities/todo.dart';
import '../error/failure.dart';
import '../repositories/todo_repository.dart';

class GetTodosUseCase
    implements UseCase<Either<Failure, List<Todo>>, NoParams> {
  late final TodoRepository repository;

  GetTodosUseCase(this.repository); // Pass the repository through constructor

  @override
  Future<Either<Failure, List<Todo>>> call(NoParams params) async {
    // Implementing the logic to fetch todos from the repository or data source
    // try {
    //   final todos = await repository.getAllTodos();
    //   return Right(todos as List<Todo>);
    // } catch (e) {
    //   return const Left(Failure("Failed to fetch todos"));
    // }
    return await repository.getAllTodos();
  }
}
