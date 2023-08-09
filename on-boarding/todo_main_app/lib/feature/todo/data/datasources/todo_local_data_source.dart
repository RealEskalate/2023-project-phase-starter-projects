import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/feature/todo/data/datasources/todo_data_source.dart';

class TodoLocalDataSource implements TodoDataSource {
  // Implement methods to interact with a local database or storage
  @override
  Future<List<Todo>> getAllTodos() async {
    // TODO: Replace with actual database queries
    return [];
  }
}
