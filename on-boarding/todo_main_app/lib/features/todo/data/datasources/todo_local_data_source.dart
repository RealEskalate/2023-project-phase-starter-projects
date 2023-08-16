import 'dart:async';
import 'dart:convert';

import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/models/todo_model.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

const CACHED_TODO = 'CACHED_TODO';

class TodoLocalDataSourceImp implements TodoLocalDataSource {
  final SharedPreferences sharedPreferences;

  TodoLocalDataSourceImp({required this.sharedPreferences});

  @override
  Future<List<Todo>> getAllTodos() async {
    final jsonString = sharedPreferences.getString(CACHED_TODO);
    if (jsonString != null) {
      final List<dynamic> jsonList = json.decode(jsonString);
      final todos =
          jsonList.map((jsonObject) => TodoModel.fromJson(jsonObject)).toList();
      return todos;
    } else {
      final defaultTodo = [
        TodoModel(
          id: 2,
          title: "Todo App UI Design",
          description:
              "Design a UI/UX for a mobile app. We can use Figma or Adobe for designing the UI.",
          dueDate: DateTime.now(),
          isCompleted: false,
        ),
        TodoModel(
          id: 3,
          title: "Todo App UI Design",
          description:
              "Design a UI/UX for a mobile app. We can use Figma or Adobe for designing the UI.",
          dueDate: DateTime.now(),
          isCompleted: false,
        ),
      ];
      return defaultTodo; // Return the default TodoModel directly
    }
  }

  @override
  Future<Todo> createTodo(Todo todo) async {
    final todos = await getAllTodos();
    final newTodo = TodoModel(
      id: todos.length + 1, // Generate a new ID
      title: todo.title,
      description: todo.description,
      dueDate: todo.dueDate,
      isCompleted: false, // New todos are not completed by default
    );
    todos.add(newTodo);
    await saveTodos(todos);
    return newTodo;
  }

  @override
  Future<Todo> updateTodo(Todo todo) async {
    final todos = await getAllTodos();
    final index = todos.indexWhere((t) => t.id == todo.id);
    if (index != -1) {
      final updatedTodo = TodoModel(
        id: todo.id,
        title: todo.title,
        description: todo.description,
        dueDate: todo.dueDate,
        isCompleted: todo.isCompleted,
      );
      todos[index] = updatedTodo;
      await saveTodos(todos);
      return updatedTodo;
    } else {
      throw Exception('Todo with ID ${todo.id} not found.');
    }
  }

  @override
  Future<bool> deleteTodo(int todoId) async {
    final todos = await getAllTodos();
    final index = todos.indexWhere((t) => t.id == todoId);
    if (index != -1) {
      todos.removeAt(index);
      await saveTodos(todos);
      return true;
    } else {
      return false;
    }
  }

  @override
  Future<Todo> getTodoById(int todoId) async {
    final todos = await getAllTodos();
    final todo = todos.firstWhere((t) => t.id == todoId,
        orElse: () => throw Exception('Todo with ID $todoId not found.'));
    return todo;
  }

  Future<void> saveTodos(List<Todo> todos) async {
    final todoListJson = todos.map((todo) => todo.toJson()).toList();
    final jsonString = json.encode(todoListJson);
    await sharedPreferences.setString(CACHED_TODO, jsonString);
  }
}
