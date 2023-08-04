import 'package:todo_main_app/feature/add_task/add_task.dart';
import 'package:todo_main_app/feature/home_screen/home_page.dart';
import 'package:todo_main_app/feature/task_detail/task_detail.dart';
import 'package:todo_main_app/feature/get_started.dart';
import 'package:flutter/material.dart';

void main() {
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
      home: const HomePage(), // Remove const
      routes: {
        // '/getStarted': (context) => const GetStartedRoute(), // Remove const
        '/addTask': (context) => const AddTask(), // Remove const
        '/home': (context) => const HomePage(), // Remove const
        '/taskDetail': (context) => const TaskDetail(), // Remove const
      },
    );
  }
}
