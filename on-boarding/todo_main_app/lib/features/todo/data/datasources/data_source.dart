import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

abstract class TodoLocalDataSource {
  Future<List<Todo>> getAllTodos();
  Future<Todo> createTodo(Todo todo);
  Future<Todo> updateTodo(Todo todo);
  Future<bool> deleteTodo(int todoId);
  Future<Todo> getTodoById(int todoId);
}
