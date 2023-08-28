import 'package:go_router/go_router.dart';

import '../../../features/article/domain/entities/article.dart';
import '../../../features/article/presentation/screens/home_page.dart';
import '../../../features/article/presentation/screens/screens.dart';
import '../../../features/authentication/presentation/pages/auth_page.dart';
import '../../../features/onboard/presentation/screens/splash_screen.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  // TODO: Add all routes here

  routes: <RouteBase>[
    GoRoute(
      path: Routes.splashScreen,
      builder: (context, state) => const SplashScreen(),
    ),
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const HomePage(),
    ),
    GoRoute(
      path: Routes.articles,
      builder: (context, state) => const HomePage(),
    ),
    GoRoute(
      path: Routes.auth,
      builder: (context, state) => const AuthPage(),
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
      path: Routes.editArticle,
      builder: (context, state) {
        final article = state.extra as Article;
        return ArticleFormScreen(article: article);
      },
    ),
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const HomePage(),
    ),
  ],
);
