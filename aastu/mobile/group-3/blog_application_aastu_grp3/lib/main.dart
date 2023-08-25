import 'package:animated_splash_screen/animated_splash_screen.dart';
import 'package:blog_application_aastu_grp3/core/theme.dart';
import 'package:flutter/material.dart';

import 'features/onboarding/onboarding.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  //
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: customTheme,
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: AnimatedSplashScreen(
          splashIconSize: 150,
          splashTransition: SplashTransition.slideTransition,
          duration: 5,
          animationDuration: Duration(seconds: 2),
          splash: Image.asset('assets/images/a2sv_logo.png'),
          nextScreen: OnBoarding()),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(),
    );
  }
}
