import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import '../../domain/entities/todo.dart';

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
  Future<Either<Failure, Todo>> getSingleTask(int todoId) async {
    try {
      final todo = await localDataSource.getTodoById(todoId);
      return Right(todo);
    } catch (e) {
      return const Left(ServerFailure("Failed to get single task"));
    }
  }

  @override
  Future<Either<Failure, Todo>> createTask(Todo todo) async {
    try {
      final createdTodo = await localDataSource.createTodo(todo);
      return Right(createdTodo);
    } catch (e) {
      return const Left(ServerFailure("Failed to create task"));
    }
  }

  @override
  Future<Either<Failure, Todo>> updateTask(Todo todo) async {
    try {
      final updatedTodo = await localDataSource.updateTodo(todo);
      return Right(updatedTodo);
    } catch (e) {
      return const Left(ServerFailure("Failed to update task"));
    }
  }

  @override
  Future<Either<Failure, bool>> deleteTask(int todoId) async {
    try {
      final isDeleted = await localDataSource.deleteTodo(todoId);
      return Right(isDeleted);
    } catch (e) {
      return const Left(ServerFailure("Failed to delete task"));
    }
  }
}
