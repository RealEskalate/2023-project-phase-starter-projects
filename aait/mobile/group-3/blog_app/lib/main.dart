import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'features/onboarding/screens/onboarding_page.dart';
import 'features/onboarding/screens/splash_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      child: SplashScreen(),
      builder: (context, child) => MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Blog App',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        routes: {
          '/onboarding1': (context) => OnboardingScreen(),
        },
        home: child,
      ),
    );
  }
}
