import 'dart:convert';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:todo_main_app/core/entities/todo.dart';
import 'package:todo_main_app/features/todo/data/datasources/todo_local_data_source.dart';
import 'package:matcher/matcher.dart';
import '../../../../fixtures/fixture_reader.dart';

class MockSharedPreferences extends Mock implements SharedPreferences {}

void main() {
  late TodoLocalDataSource dataSource;
  late MockSharedPreferences mockSharedPreferences;

  setUp(() {
    mockSharedPreferences = MockSharedPreferences();
    dataSource = TodoLocalDataSource(sharedPreferences: mockSharedPreferences);
  });

  group('getAllTodos', () {
    Todo.fromJson(json.decode(fixture('todo_cached.json')));
    test(
      'should return a list of todos from shared preferences',
      () async {
        when(mockSharedPreferences.getString("$any"))
            .thenReturn(fixture('todo_cached.json'));

        final result = await dataSource.getAllTodos();

        verify(mockSharedPreferences.getString("todo"));
        expect(result, equals(Todo));
      },
    );

    test('should return an empty list if no data is cached', () async {
      // Arrange
      when(mockSharedPreferences.getString("todo")).thenReturn(null);

      // Act
      final result = await dataSource.getAllTodos();

      // Assert
      expect(result, isA<List<Todo>>());
      expect(result.isEmpty, true);
    });
  });

  // Add more test cases for other methods in TodoLocalDataSource
}
