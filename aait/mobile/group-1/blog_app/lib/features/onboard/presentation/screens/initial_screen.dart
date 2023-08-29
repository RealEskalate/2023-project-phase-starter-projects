import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'splash_screen.dart';
import 'splash_screen_static.dart';

class AppInitialScreen extends StatelessWidget {
  const AppInitialScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: ElevatedButton(
          onPressed: () {
            Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => const SplashScreen()),
            );
          },
          child: Center(
            child: Text("Hello"),
          )),
    );
  }
}
