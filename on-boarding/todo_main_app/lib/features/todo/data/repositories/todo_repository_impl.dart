import 'dart:developer';

import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/platform/network_info.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/domain/repositories/todo_repository.dart';
import '../../domain/entities/todo.dart';

class TodoRepositoryImpl implements TodoRepository {
  final TodoLocalDataSource localDataSource;
  final TodoRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  TodoRepositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    try {
      if (await networkInfo.isConnected) {
        try {
          log("Fetching remote data");
          final remoteTodos = await remoteDataSource.getAllTodos();
          localDataSource.cacheTodos(remoteTodos);
          return Right(remoteTodos);
        } catch (e) {
          // Handle remote data fetch error
          log("Remote data fetch error: $e");
          final localTodos = await localDataSource.getAllTodos();
          return Right(localTodos); // Fetch local data on error
        }
      } else {
        log("No internet connection");
        final localTodos = await localDataSource.getAllTodos();
        return Right(localTodos);
      }
    } catch (e) {
      return const Left(ServerFailure("Failed to get all tasks"));
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
