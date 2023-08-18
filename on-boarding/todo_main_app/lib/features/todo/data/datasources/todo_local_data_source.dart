import 'dart:async';
import 'dart:convert';
import 'dart:developer' as developer;
import 'dart:math';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/models/todo_model.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

const CACHED_TODO = 'CACHED_TODO';

class TodoLocalDataSourceImp implements TodoLocalDataSource {
  final SharedPreferences sharedPreferences;

  TodoLocalDataSourceImp({required this.sharedPreferences});
  var random = Random();

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
          id: 0,
          title: "Test",
          description: "Test",
          dueDate: DateTime.now(),
          isCompleted: false,
        ),
      ];
      return defaultTodo;
    }
  }

  @override
  Future<Todo> createTodo(Todo todo) async {
    final todos = await getAllTodos();

    var uniId = random.nextInt(9000) + 1000;

    final newTodo = TodoModel(
      id: uniId,
      title: todo.title,
      description: todo.description,
      dueDate: todo.dueDate,
      isCompleted: false, // New todos are not completed by default
    );
    developer.log("newTodo $newTodo.toString()");
    // log print title and id
    developer.log("newTodo $newTodo.title");
    developer.log("newTodo $newTodo.id");

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
    final index = todos.indexWhere((task) => task.id == todoId);
    if (index >= 0) {
      final todo = todos[index];
      return todo;
    } else {
      throw Exception(
          'Todo with ID $todoId not found.'); // Add a throw statement
    }
  }

  Future<void> saveTodos(List<Todo> todos) async {
    final todoListJson = todos.map((todo) => todo.toJson()).toList();
    final jsonString = json.encode(todoListJson);
    await sharedPreferences.setString(CACHED_TODO, jsonString);
  }
}
