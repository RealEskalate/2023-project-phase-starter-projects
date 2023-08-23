import 'package:blog_app/core/bloc.dart';
import 'package:blog_app/features/blog/presentation/screen/addBlog.dart';
import 'package:blog_app/features/blog/presentation/screen/editBlog.dart';
import 'package:blog_app/features/blog/presentation/screen/home_screen.dart';
import 'package:blog_app/features/blog/presentation/screen/viewBlog.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
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
      title: 'Blog App',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
        useMaterial3: true,
      ),
      home: const Edit1Blog(), // TODO: Replace with the Onboarding
      routes: {
        '/home': (context) => const Edit1Blog(),
        // define routes here
      },
    );
  }
}
