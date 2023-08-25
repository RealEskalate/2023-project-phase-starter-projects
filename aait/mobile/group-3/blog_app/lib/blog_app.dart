import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:blog_app/features/profile/presentation/screen/profile_screen.dart';
import 'package:blog_app/injection_container.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'features/onboarding/screens/onboarding_page.dart';
import 'features/onboarding/screens/splash_screen.dart';

class BlogApp extends StatelessWidget {
  const BlogApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(path: '/', builder: (context,state)=>SplashScreen()), 
      GoRoute(path: '/onboarding', builder: (context,state)=>OnboardingScreen()), 
      // GoRoute(path: '/login', builder: null), //TODO: IMPLEMENT LOGIN SCREEN
      // GoRoute(path: '/home', builder: null), //=> TODO: IMPLEMENT HOME SCREEN,
      // GoRoute(
      //     path: '/article', builder: null), //=> TODO: IMPLEMENT ARTICLE SCREEN
      GoRoute(path: '/profile', builder: (context, state) => ProfileScreen()),
    ]);
    //TODO: ADD BLOC
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) {
        return MaterialApp(
            home: MultiBlocProvider(
          providers: [
            BlocProvider(
              create: (context) => serviceLocator<ProfileBloc>(),
            ),
          ],
          child: MaterialApp.router(
            routerConfig: _router,
          ),
        ));
      },
    );
  }
}
