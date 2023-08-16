import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';

class ServerFailure extends Failure {
  final String message;

  const ServerFailure(this.message) : super('');

  @override
  List<Object> get props => [message];
}

class TodoRepositoryImpl implements TodoRepository {
  final TodoLocalDataSource localDataSource;

  TodoRepositoryImpl(this.localDataSource);

  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    try {
      final todos = await localDataSource.getAllTodos();
      return Right(todos);
    } catch (e) {
      return const Left(ServerFailure("Failed to get all todos"));
    }
  }

  @override
  Future<Either<Failure, Todo>> createTodo(Todo todo) async {
    try {
      final createdTodo = await localDataSource.createTodo(todo);
      return Right(createdTodo);
    } catch (e) {
      return const Left(ServerFailure("Failed to create todo"));
    }
  }

  @override
  Future<Either<Failure, Todo>> updateTodo(Todo todo) async {
    try {
      final updatedTodo = await localDataSource.updateTodo(todo);
      return Right(updatedTodo);
    } catch (e) {
      return const Left(ServerFailure("Failed to update todo"));
    }
  }
}
