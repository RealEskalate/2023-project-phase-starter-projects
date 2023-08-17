import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:todo_main_app/features/todo/domain/entities/todo.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/bloc.dart';
import 'package:todo_main_app/features/todo/presentation/pages/task_list.dart';
import 'package:todo_main_app/features/todo/presentation/widgets/single_list_card.dart';

class MockTodoBloc extends Mock implements TodoBloc {}

void main() {
  late MockTodoBloc mockTodoBloc;

  setUp(() {
    mockTodoBloc = MockTodoBloc();
  });

  Widget makeTestableWidget({Widget? child, MockTodoBloc? todoBloc}) {
    return MaterialApp(
      home: child,
    );
  }

  testWidgets('renders TaskListRoute', (WidgetTester tester) async {
    final tasks = [
      Todo(
          id: 2,
          title: 'Task 2',
          description: "",
          dueDate: DateTime.now(),
          isCompleted: false),
      Todo(
          id: 2,
          title: 'Task 2',
          description: "",
          dueDate: DateTime.now(),
          isCompleted: false)
    ];

    when(mockTodoBloc.state).thenReturn(LoadedAllTasksState(tasks));

    await tester.pumpWidget(
      makeTestableWidget(
        child: const TaskListRoute(),
      ),
    );

    // Verify that the TaskListRoute UI elements are rendered
    expect(find.text('Todo List'), findsOneWidget);
    expect(find.text('Tasks List'), findsOneWidget);
    expect(find.byType(ElevatedButton), findsOneWidget);
    expect(find.byType(SingleListCard), findsNWidgets(tasks.length));
  });

  testWidgets('renders empty task list', (WidgetTester tester) async {
    when(mockTodoBloc.state).thenReturn(InitialState());

    await tester.pumpWidget(
      makeTestableWidget(
        child: const TaskListRoute(),
      ),
    );

    // Verify that the TaskListRoute UI elements are rendered
    expect(find.text('Todo List'), findsOneWidget);
    expect(find.text('Tasks List'), findsOneWidget);
    expect(find.byType(ElevatedButton), findsOneWidget);
    expect(find.byType(SingleListCard), findsNothing);
  });
}
