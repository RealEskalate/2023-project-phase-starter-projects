import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_data_source.dart';

class TodoLocalDataSource implements TodoDataSource {
  final SharedPreferences sharedPreferences;

  TodoLocalDataSource({required this.sharedPreferences});

  @override
  Future<List<Todo>> getAllTodos() async {
    final jsonString = sharedPreferences.getString('todos');
    if (jsonString != null) {
      final List<dynamic> todoListJson = json.decode(jsonString);
      final todos = todoListJson.map((json) => Todo.fromJson(json)).toList();
      return todos;
    } else {
      return [];
    }
  }

  @override
  Future<Todo> createTodo(Todo todo) async {
    final todos = await getAllTodos();
    todos.add(todo);
    await saveTodos(todos);
    return todo;
  }

  @override
  Future<Todo> updateTodo(Todo todo) async {
    final todos = await getAllTodos();
    final index = todos.indexWhere((t) => t.id == todo.id);
    if (index != -1) {
      todos[index] = todo;
      await saveTodos(todos);
    }
    return todo;
  }

  @override
  Future<bool> markTodoAsCompleted(int todoId) async {
    final todos = await getAllTodos();
    final index = todos.indexWhere((t) => t.id == todoId);
    if (index != -1) {
      todos[index] = todos[index].copyWith(isCompleted: true);
      await saveTodos(todos);
      return true;
    }
    return false;
  }

  @override
  Future<Todo> getTodoById(int todoId) async {
    final todos = await getAllTodos();
    final todo =
        todos.firstWhere((t) => t.id == todoId, orElse: () => Todo.empty());
    return todo;
  }

  @override
  Future<bool> deleteTodo(int todoId) async {
    final todos = await getAllTodos();
    final index = todos.indexWhere((t) => t.id == todoId);
    if (index != -1) {
      todos.removeAt(index);
      await saveTodos(todos);
      return true; // Deletion was successful
    }
    return false; // Todo with the specified ID was not found
  }

  Future<void> saveTodos(List<Todo> todos) async {
    final todoListJson = todos.map((todo) => todo.toJson()).toList();
    final jsonString = json.encode(todoListJson);
    await sharedPreferences.setString('todos', jsonString);
  }
}
