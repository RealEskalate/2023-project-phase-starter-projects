import "package:blog_application/features/blog/presentation/pages/create_article_screans.dart";
import "package:blog_application/features/blog/presentation/screens/home_page.dart";
import "package:blog_application/features/blog/presentation/screens/profile_screen.dart";
import 'package:flutter/material.dart';
// import 'package:todo_app/features/todo/domain/entities/task_entity.dart';
import "./core/routes/blog_app_routes.dart";

import "./features/blog/presentation/pages/auth.dart";
import "./features/blog/presentation/pages/articles_reading_screen.dart";

// const String onBoarding = "onboarding";
// const String auth = "auth";
// const String home = "home";
// const String profile = "profile";
// const String createTask = "createTask";

Route<dynamic> controller(RouteSettings settings) {
  switch (settings.name) {
    case BlogAppRoutes.AUTH:
      return MaterialPageRoute(builder: (context) => const Auth());
    case BlogAppRoutes.ARTICLE_DETAIL:
      return MaterialPageRoute(builder: (context) => const ArticleReading(likes: 4));
    case BlogAppRoutes.HOME:
      return MaterialPageRoute(builder: (context) => const HomePage());
    case BlogAppRoutes.ARTICLE_CREATE:
      return MaterialPageRoute(builder: (context) => CreateTaskScreen());
    case BlogAppRoutes.PROFILE:
      return MaterialPageRoute(builder: (context) => const ProfileScreen());
    default:
      return throw ("invalid navigation");
  }
}
