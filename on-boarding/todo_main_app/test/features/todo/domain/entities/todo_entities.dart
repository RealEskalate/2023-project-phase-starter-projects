import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

void main() {
  group('Todo entity', () {
    test('should create a Todo instance with default values', () {
      final todo = Todo.empty();

      expect(todo.id, -1);
      expect(todo.title, '');
      expect(todo.description, '');
      expect(todo.dueDate, isNotNull);
      expect(todo.isCompleted, false);
    });

    test('should convert Todo to JSON', () {
      final todo = Todo(
        id: 1,
        title: 'Task 1',
        description: 'Description for Task 1',
        dueDate: DateTime.parse('2023-08-16T10:00:00Z'),
        isCompleted: true,
      );

      final json = todo.toJson();

      expect(json['id'], 1);
      expect(json['title'], 'Task 1');
      expect(json['description'], 'Description for Task 1');
      expect(json['dueDate'], '2023-08-16T10:00:00.000Z');
      expect(json['isCompleted'], true);
    });

    test('should create a Todo instance from JSON', () {
      final json = {
        'id': 2,
        'title': 'Task 2',
        'description': 'Description for Task 2',
        'dueDate': '2023-08-17T12:00:00Z',
        'isCompleted': false,
      };

      final todo = Todo.fromJson(json);

      expect(todo.id, 2);
      expect(todo.title, 'Task 2');
      expect(todo.description, 'Description for Task 2');
      expect(todo.dueDate, DateTime.parse('2023-08-17T12:00:00Z'));
      expect(todo.isCompleted, false);
    });
  });
}
