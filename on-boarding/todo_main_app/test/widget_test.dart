import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/add_task.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/task_list.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/on_boarding.dart';
import 'package:todo_main_app/feature/todo/presentation/widgets/task_detail.dart';

void main() {
  testWidgets('TaskDetail widget displays title correctly', (tester) async {
    const String testTitle = 'Test Title'; // Define the test title
    await tester.pumpWidget(
      const MaterialApp(
        home: TaskDetail(
          taskId: 0,
        ),
      ),
    );

    final titleFinder = find.text(testTitle);
    final descriptionFinder = find.text('testDescription');
    expect(titleFinder, findsOneWidget);
    expect(descriptionFinder, findsOneWidget);
  });

  testWidgets('AddTask widget displays UI elements correctly', (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: AddTask(),
      ),
    );

    // Test various UI elements' presence
    expect(find.text('Create New Task'), findsOneWidget);
    expect(find.text('Main Task Name'), findsOneWidget);
    expect(find.text('Due Date'), findsOneWidget);
    expect(find.text('Description'), findsOneWidget);
    expect(find.byType(TextField),
        findsNWidgets(2)); // Task name and Description fields
    expect(find.byType(ElevatedButton), findsOneWidget);
  });

  testWidgets('AddTask widget does not add task with empty name',
      (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: AddTask(),
      ),
    );

    final textFieldFinder = find.byKey(const Key('task_name_field'));
    final textField = tester.widget<TextField>(textFieldFinder);

    expect(textField.controller!.text.isEmpty, isTrue);
  });

  testWidgets('AddTask widget displays selected date correctly',
      (tester) async {
    await tester.pumpWidget(
      const MaterialApp(
        home: AddTask(),
      ),
    );

    await tester.tap(find.byKey(const Key('date_picker_icon')));
    await tester.pumpAndSettle();

    // Verify that the date picker is displayed
    expect(find.byType(CalendarDatePicker), findsOneWidget);
  });

  // testWidgets('TaskList widget displays UI elements correctly', (tester) async {
  //   await tester.pumpWidget(
  //     const MaterialApp(
  //       home: TaskListRoute(),
  //     ),
  //   );

  //   // Test various UI elements' presence
  //   expect(find.text('Todo App UI Design'), findsOneWidget);
  // });

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
