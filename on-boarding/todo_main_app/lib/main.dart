import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:todo_main_app/core/bloc.dart';
import 'package:todo_main_app/features/todo/presentation/bloc/todo_bloc.dart';
import 'package:todo_main_app/features/todo/presentation/pages/task_list.dart';
import 'package:todo_main_app/features/todo/presentation/pages/add_task.dart';
import 'package:todo_main_app/features/todo/presentation/widgets/on_boarding.dart';
import 'package:flutter/material.dart';
import 'injection.dart' as di;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await di.init();
  Bloc.observer = const AppBlocObserver();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

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
        '/addTask': (context) {
          final todoBloc = BlocProvider.of<TodoBloc>(context);
          return AddTask(todoBloc: todoBloc);
        },
        '/home': (context) => const TaskListRoute(),
      },
    );
  }
}
