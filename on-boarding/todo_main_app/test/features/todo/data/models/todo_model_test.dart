import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/features/todo/data/models/todo_model.dart';

void main() {
  group('TodoModel', () {
    test('fromJson should return a valid TodoModel', () {
      final Map<String, dynamic> jsonMap = {
        'id': 1,
        'title': 'Test Todo',
        'description': 'This is a test todo',
        'dueDate': '2023-08-10T10:00:00Z',
        'isCompleted': false,
      };

      final result = TodoModel.fromJson(jsonMap);

      expect(result, isA<TodoModel>());
      expect(result.id, 1);
      expect(result.title, 'Test Todo');
      expect(result.description, 'This is a test todo');
      expect(result.dueDate, DateTime.utc(2023, 8, 10, 10, 0, 0));
      expect(result.isCompleted, false);
    });

    test('toJson should return a valid JSON map', () {
      final todo = TodoModel(
        id: 1,
        title: 'Test Todo',
        description: 'This is a test todo',
        dueDate: DateTime.utc(2023, 8, 10, 10, 0, 0),
        isCompleted: false,
      );

      final result = todo.toJson();

      final expectedMap = {
        'id': 1,
        'title': 'Test Todo',
        'description': 'This is a test todo',
        'dueDate': '2023-08-10T10:00:00.000Z',
        'isCompleted': false,
      };

      expect(result, expectedMap);
    });
  });
}
