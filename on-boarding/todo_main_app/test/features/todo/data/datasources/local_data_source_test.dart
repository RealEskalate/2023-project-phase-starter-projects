import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:todo_main_app/features/todo/data/models/todo_model.dart';

class MockSharedPreferences extends Mock implements SharedPreferences {}

void main() {
  late TodoLocalDataSourceImp dataSource;
  late MockSharedPreferences mockSharedPreferences;

  setUp(() {
    mockSharedPreferences = MockSharedPreferences();
    dataSource =
        TodoLocalDataSourceImp(sharedPreferences: mockSharedPreferences);
  });

  group('getAllTodos', () {
    test(
        'should return a list of TodoModel from SharedPreferences when data is available',
        () async {
      // Arrange
      const jsonString = '''
        [
          {"id": 1, "title": "Todo 1", "description": "Description 1", "dueDate": "2023-08-16T12:00:00.000Z", "isCompleted": false},
          {"id": 2, "title": "Todo 2", "description": "Description 2", "dueDate": "2023-08-17T12:00:00.000Z", "isCompleted": true}
        ]
      ''';
      when(mockSharedPreferences.getString("$any")).thenReturn(jsonString);

      // Act
      final result = await dataSource.getAllTodos();

      // Assert
      final expectedList = [
        TodoModel(
            id: 1,
            title: 'Todo 1',
            description: 'Description 1',
            dueDate: DateTime.parse('2023-08-16T12:00:00.000Z'),
            isCompleted: false),
        TodoModel(
            id: 2,
            title: 'Todo 2',
            description: 'Description 2',
            dueDate: DateTime.parse('2023-08-17T12:00:00.000Z'),
            isCompleted: true),
      ];
      expect(result, equals(expectedList));
      verify(mockSharedPreferences.getString('CACHED_TODO'));
    });

    test('should return a default list of TodoModel when data is not available',
        () async {
      // Arrange
      when(mockSharedPreferences.getString("$any")).thenReturn(null);

      // Act
      final result = await dataSource.getAllTodos();

      // Assert
      final expectedList = [
        TodoModel(
            id: 0,
            title: 'Todo App UI Design',
            description:
                'Design a UI/UX for mobile app. We can use figma or Adobe for designing the UI.',
            dueDate: DateTime.now(),
            isCompleted: false),
      ];
      expect(result, equals(expectedList));
      verify(mockSharedPreferences.getString('CACHED_TODO'));
    });
  });
}
