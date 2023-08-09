import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/usecases/usescases.dart';

import '../entities/todo.dart';
import '../failure.dart';
import '../repositories/todo_repository.dart';

class GetTodosUseCase
    implements UseCase<Either<Failure, List<Todo>>, NoParams> {
  late final TodoRepository repository;

  GetTodosUseCase(this.repository); // Pass the repository through constructor

  @override
  Future<Either<Failure, List<Todo>>> call(NoParams params) async {
    // Implementing the logic to fetch todos from the repository or data source
    try {
      final todos = await repository.getAllTodos();
      return Right(todos as List<Todo>);
    } catch (e) {
      return Left(Failure("Failed to fetch todos"));
    }
  }
}
