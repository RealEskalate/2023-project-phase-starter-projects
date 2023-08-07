import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/feature/presentation/widgets/task_detail.dart';

void main() {
  testWidgets('TaskDetail widget displays title correctly', (tester) async {
    const String testTitle = 'Test Title'; // Define the test title

    await tester.pumpWidget(
      const MaterialApp(
        home: TaskDetail(title: testTitle),
      ),
    );

    final titleFinder = find.text(testTitle);
    expect(titleFinder, findsOneWidget);
  });
}
