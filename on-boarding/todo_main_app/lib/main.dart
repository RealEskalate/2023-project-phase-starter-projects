import 'package:todo_main_app/feature/presentation/widgets/add_task.dart';
import 'package:todo_main_app/feature/presentation/widgets/home_page.dart';
import 'package:todo_main_app/feature/presentation/widgets/task_detail.dart';
import 'package:todo_main_app/feature/presentation/widgets/on_boarding.dart';
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
      home: const GetStartedRoute(), // Remove const
      routes: {
        '/addTask': (context) => const AddTask(),
        '/home': (context) => const HomePage(),
        '/taskDetail': (context) =>
            const TaskDetail(title: "", description: ""),
      },
    );
  }
}
