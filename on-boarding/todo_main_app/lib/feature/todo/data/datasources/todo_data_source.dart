import 'package:todo_main_app/core/entities/todo.dart';

abstract class TodoDataSource {
  Future<List<Todo>> getAllTodos();
  //TODO: Add other methods as needed for interacting with the data source
}
