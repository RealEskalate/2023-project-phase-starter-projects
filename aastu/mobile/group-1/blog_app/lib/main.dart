import 'package:blog_app/core/bloc.dart';
import 'package:blog_app/features/blog/presentation/screen/home_screen.dart';
import 'package:blog_app/features/user/presentation/pages/user_profile_screen.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:blog_app/features/onboarding/screens/splash.dart';
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
      title: 'BLOG APP',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, secondary: const Color(0xffEE6F57)),
        useMaterial3: true,
      ),
      home: const Splash(), // TODO: Replace with the Onboarding
      routes: {
        '/home': (context) => const Home(),
        '/profile': (context) => const UserProfileScreen(),

        // define routes here
      },
    );
  }
}
