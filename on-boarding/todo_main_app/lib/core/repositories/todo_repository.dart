import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/failure.dart';

abstract class TodoRepository {
  Future<Either<Failure, List<Todo>>> getAllTodos();
}
