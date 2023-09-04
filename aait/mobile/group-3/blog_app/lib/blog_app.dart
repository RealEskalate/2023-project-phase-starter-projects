import 'package:blog_app/features/article/presentation/bloc/article_bloc.dart';
import 'package:blog_app/features/article/presentation/bloc/create_article_bloc.dart';
import 'package:blog_app/features/article/presentation/bloc/update_article_bloc.dart';
import 'package:blog_app/features/article/presentation/screen/article_reading.dart';
import 'package:blog_app/features/article/presentation/screen/home_screen.dart';
import 'package:blog_app/features/article/presentation/screen/update_article_page.dart';
import 'package:blog_app/features/article/presentation/screen/write_aricle_page.dart';
import 'package:blog_app/features/auth/presentation/bloc/login_bloc/bloc/login_bloc.dart';
import 'package:blog_app/features/auth/presentation/bloc/signup_bloc/bloc/signup_bloc.dart';
import 'package:blog_app/features/auth/presentation/screen/login_signup_page.dart';
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
      GoRoute(path: '/', builder: (context, state) => SplashScreen()),
      GoRoute(path: '/', builder: (context, state) => HomeScreen()),
      GoRoute(
          path: '/onboarding', builder: (context, state) => OnboardingScreen()),
      GoRoute(path: '/login', builder: (context, state) => LoginSignUpPage()),
      GoRoute(path: '/home', builder: (context, state) => HomeScreen()),
      GoRoute(
          path: '/create_article',
          builder: (context, state) => WriteArticlePage()),
      GoRoute(
        path: '/update_article',
        builder: (context, state) => UpdateArticlePage(
          articleId: state.extra! as String,
        ),
      ),
      GoRoute(
        path: '/article',
        builder: (context, state) => ArticleReadingPage(
          id: state.extra! as String,
        ),
      ),
      GoRoute(path: '/profile', builder: (context, state) => ProfileScreen()),
    ]);
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      minTextAdapt: true,
      splitScreenMode: true,
      builder: (_, child) {
        return MaterialApp(
            debugShowCheckedModeBanner: false,
            home: MultiBlocProvider(
              providers: [
                BlocProvider(
                  create: (context) => serviceLocator<ProfileBloc>(),
                ),
                BlocProvider(
                  create: (context) => serviceLocator<LoginBloc>(),
                ),
                BlocProvider(
                  create: (context) => serviceLocator<SignupBloc>(),
                ),
                BlocProvider(
                  create: (context) => serviceLocator<ArticleBloc>(),
                ),
                BlocProvider(
                  create: (context) => serviceLocator<CreateArticleBloc>(),
                ),
                BlocProvider(
                    create: (context) => serviceLocator<UpdateArticleBloc>())
              ],
              child: MaterialApp.router(
                debugShowCheckedModeBanner: false,
                routerConfig: _router,
              ),
            ));
      },
    );
  }
}
