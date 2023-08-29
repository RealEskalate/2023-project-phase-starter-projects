import 'package:go_router/go_router.dart';

import '../../../features/article/domain/entities/article.dart';
import '../../../features/article/presentation/screens/home_page.dart';
import '../../../features/article/presentation/screens/screens.dart';
import '../../../features/authentication/presentation/pages/auth_page.dart';
import '../../../features/onboard/presentation/screens/initial_screen.dart';
import '../../../features/onboard/presentation/screens/on_boarding.dart';
import '../../../features/user/presentation/screens/user_profile.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  // TODO: Add all routes here

  routes: <RouteBase>[
    // Debug area
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const AppInitialScreen(),
    ),
    // Debug end!

    GoRoute(
      path: Routes.onBoard,
      builder: (context, state) => const OnBoarding(),
    ),

    // auth
    GoRoute(
      path: Routes.auth,
      builder: (context, state) => const AuthPage(),
    ),

    // article
    GoRoute(
      path: Routes.articles,
      builder: (context, state) => const HomePage(),
    ),

    GoRoute(
      path: Routes.articleDetail,
      builder: (context, state) {
        final article = state.extra as Article;
        return ArticleScreen(article: article);
      },
    ),

    // Auth routes
    GoRoute(
      path: Routes.createArticle,
      builder: (context, state) {
        return const ArticleFormScreen();
      },
    ),

    GoRoute(
      path: Routes.editArticle,
      builder: (context, state) {
        final article = state.extra as Article;
        return ArticleFormScreen(article: article);
      },
    ),

    GoRoute(
      path: Routes.profileScreen,
      builder: (context, state) => const UserProfile(),
    ),
  ],
);
