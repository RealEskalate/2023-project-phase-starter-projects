import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:todo_main_app/core/bloc.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/todo_bloc.dart';
import 'package:todo_main_app/features/todo/presentation/pages/task_detail.dart';
import 'package:todo_main_app/features/todo/presentation/pages/task_list.dart';
import 'package:todo_main_app/features/todo/presentation/pages/add_task.dart';
import 'package:todo_main_app/features/todo/presentation/pages/on_boarding.dart';
import 'package:flutter/material.dart';
import 'injection.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = const AppBlocObserver();
  final todoBloc = TodoBloc(
      getAllTasks: di.sl(),
      getSingleTask: di.sl(),
      updateTask: di.sl(),
      deleteTask: di.sl());
  runApp(MyApp(todoBloc: todoBloc));
}

class MyApp extends StatelessWidget {
  final TodoBloc todoBloc; // Add this

  const MyApp({required this.todoBloc, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Todo App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
        useMaterial3: true,
      ),
      home: const GetStartedRoute(), // Remove const
      routes: {
        '/addTask': (context) =>
            AddTask(todoBloc: todoBloc), // Use the passed todoBloc
        '/home': (context) => const TaskListRoute(),
        '/taskDetail': (context) => const TaskDetail(
              taskId: 0,
            ),
      },
    );
  }
}
