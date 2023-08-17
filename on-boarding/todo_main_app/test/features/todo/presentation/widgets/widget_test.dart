import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/features/todo/presentation/pages/task_list.dart';
import 'package:todo_main_app/features/todo/presentation/pages/on_boarding.dart';

void main() {
  testWidgets('Tapping Get Started navigates to the main page', (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: GetStartedRoute(),
      ),
    );

    // Find the Get Started button and tap it
    final getStartedButton = find.text('Get Started');
    await tester.tap(getStartedButton);
    await tester.pumpAndSettle();

    // Verify that the main To-Do list page is displayed
    expect(find.byType(TaskListRoute), findsOneWidget);
  });
}
