import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

class TodoModel extends Todo {
  TodoModel({
    required int id,
    required String title,
    required String description,
    required DateTime dueDate,
    required bool isCompleted,
  }) : super(
            id: id,
            title: title,
            description: description,
            dueDate: dueDate,
            isCompleted: isCompleted);

  factory TodoModel.fromJson(Map<String, dynamic> json) {
    return TodoModel(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      dueDate: DateTime.parse(json['dueDate']),
      isCompleted: json['isCompleted'],
    );
  }

  @override
  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'title': title,
      'description': description,
      'dueDate': dueDate.toIso8601String(),
      'isCompleted': isCompleted,
    };
  }

  static TodoModel empty() {
    return TodoModel(
      id: -1,
      title: '',
      description: '',
      dueDate: DateTime.now(),
      isCompleted: false,
    );
  }
}
