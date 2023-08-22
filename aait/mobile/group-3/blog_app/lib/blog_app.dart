import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class BlogApp extends StatelessWidget {
  const BlogApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(path: '/', builder: null), // => TODO: IMPLEMENT LANDING SCREEN
      GoRoute(path: '/login', builder: null), //TODO: IMPLEMENT LOGIN SCREEN
      GoRoute(path: '/home', builder: null), //=> TODO: IMPLEMENT HOME SCREEN,
      GoRoute(
          path: '/article', builder: null), //=> TODO: IMPLEMENT ARTICLE SCREEN
      GoRoute(path: '/profile', builder: null), //TODO: IMPLEMENT PROFILE SCREEN
    ]);
    //TODO: ADD BLOC
    return MaterialApp.router(
      routerConfig: _router,
    );
  }
}
