import 'package:blog_app/features/user_profile/presentation/bloc/profile_bloc.dart';
import 'package:device_preview/device_preview.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import './features/user_profile/presentation/pages/profile.dart';
import 'features/intro_screens/onboarding_screens/onboarding_screen1.dart';
import 'features/intro_screens/splash_screen/splashScreenpage.dart';
import 'injection_container.dart' as di;

void main() async {
  await di.init();
  runApp(
    DevicePreview(
      enabled: !kReleaseMode,
      builder: (context) => ProviderScope(
          child: MultiBlocProvider(providers: [
        BlocProvider(
          create: (context) => ProfileBloc(),
        ),
      ], child: const MyApp())), // Wrap your app
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      //DevicePreview
      locale: DevicePreview.locale(context),
      builder: DevicePreview.appBuilder,
      debugShowCheckedModeBanner: false,
      //DevicePreview

      darkTheme: ThemeData.dark(),
      home: SplashScreen(),
    );
  }
}
