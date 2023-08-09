import 'package:dartz/dartz.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/core/error/failure.dart';
import 'package:todo_main_app/core/repositories/todo_repository.dart';

class TodoRepositoryImpl implements TodoRepository {
  @override
  Future<Either<Failure, List<Todo>>> getAllTodos() async {
    // TODO: Implement getAllTodos

    return const Right([]);
  }

  Future<List<Todo>> fetchDataFromDataSource() async {
    // TODO: Implement data retrieval logic here For example, fetch data from a database or an API

    return []; // Replace with actual data
  }
}
