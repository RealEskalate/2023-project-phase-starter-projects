import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:blog_app/features/profile/presentation/screen/profile_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class BlogApp extends StatelessWidget {
  const BlogApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      // GoRoute(path: '/', builder: null), // => TODO: IMPLEMENT LANDING SCREEN
      // GoRoute(path: '/login', builder: null), //TODO: IMPLEMENT LOGIN SCREEN
      // GoRoute(path: '/home', builder: null), //=> TODO: IMPLEMENT HOME SCREEN,
      // GoRoute(
      //     path: '/article', builder: null), //=> TODO: IMPLEMENT ARTICLE SCREEN
      GoRoute(path: '/', builder: (context, state) => ProfileScreen()),
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
              create: (context) => ProfileBloc(),
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
