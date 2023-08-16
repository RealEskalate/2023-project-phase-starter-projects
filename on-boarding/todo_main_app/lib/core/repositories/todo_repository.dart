import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';

abstract class TodoRepository {
  Future<Either<Failure, List<Todo>>> getAllTodos();
  Future<Either<Failure, Todo>> getSingleTask(int todoId);
  Future<Either<Failure, Todo>> createTask(Todo todo);
  Future<Either<Failure, Todo>> updateTask(Todo todo);
  Future<Either<Failure, bool>> deleteTask(int todoId);
  Future<Either<Failure, bool>> markTodoAsCompleted(int todoId);
}
