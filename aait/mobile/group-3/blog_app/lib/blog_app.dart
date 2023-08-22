import 'package:flutter/material.dart';
class BlogApp extends StatelessWidget {
  const BlogApp({super.key});

  @override
  Widget build(BuildContext context) {
    final GoRouter _router =
        GoRouter(navigatorKey: GlobalKey<NavigatorState>(), routes: [
      GoRoute(path: '/', builder: null), 
      GoRoute(path: '/login', builder: null), 
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
