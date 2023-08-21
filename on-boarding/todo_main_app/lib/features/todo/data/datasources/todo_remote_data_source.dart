import 'dart:convert';
import 'dart:developer';
import 'package:http/http.dart' as http;
import 'package:todo_main_app/features/todo/data/datasources/data_source.dart';
import 'package:todo_main_app/features/todo/data/models/todo_model.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

class TodoRemoteDataSourceImp implements TodoRemoteDataSource {
  final String baseUrl;

  TodoRemoteDataSourceImp({required this.baseUrl});

  @override
  Future<List<Todo>> getAllTodos() async {
    final url = Uri.parse('$baseUrl/todos/'); // Update with your API endpoint
    final response = await http.get(url);

    if (response.statusCode == 200) {
      log("Data Fetched From API${response.body}");
      final List<dynamic> jsonList = json.decode(response.body);
      final todos = jsonList
          .map((jsonObject) => TodoModel.fromAPIJson(jsonObject))
          .toList();
      return todos;
    } else {
      throw Exception('Failed to fetch todos');
    }
  }

  @override
  Future<Todo> createTodo(Todo todo) async {
    final url = Uri.parse('$baseUrl/todos/'); // Update with your API endpoint
    final headers = {'Content-Type': 'application/json'};
    final requestBody = json.encode(todo.toJson());

    final response = await http.post(url, headers: headers, body: requestBody);

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      return TodoModel.fromAPIJson(jsonResponse);
    } else {
      throw Exception('Failed to create todo');
    }
  }

  @override
  Future<bool> deleteTodo(int todoId) {
    // TODO: implement deleteTodo
    throw UnimplementedError();
  }

  @override
  Future<Todo> getTodoById(int todoId) {
    // TODO: implement getTodoById
    throw UnimplementedError();
  }

  @override
  Future<Todo> updateTodo(Todo todo) {
    // TODO: implement updateTodo
    throw UnimplementedError();
  }

  // Implement other methods (update, delete, etc.) similar to the createTodo method
}
