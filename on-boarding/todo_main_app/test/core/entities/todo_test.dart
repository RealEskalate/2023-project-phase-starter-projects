// test/core/entities/todo_test.dart

import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

void main() {
  group('Todo Entity', () {
    test('should create a Todo instance', () {
      final todo = Todo(
        id: 1,
        title: 'Sample Todo',
        description: 'This is a sample todo.',
        dueDate: DateTime.now(),
        isCompleted: false,
      );

      expect(todo.id, 1);
      expect(todo.title, 'Sample Todo');
      expect(todo.description, 'This is a sample todo.');
      expect(todo.isCompleted, false);
    });

    test('should mark a todo as completed', () {
      final incompleteTodo = Todo(
        id: 1,
        title: 'Incomplete Todo',
        description: 'This is an incomplete todo.',
        dueDate: DateTime.now(),
        isCompleted: false,
      );

      final completedTodo = incompleteTodo.copyWith(isCompleted: true);

      expect(completedTodo.isCompleted, true);
    });
  });
}
