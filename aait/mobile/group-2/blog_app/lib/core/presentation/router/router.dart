import 'package:go_router/go_router.dart';

import '../../../features/article/domain/entities/article.dart';
import '../../../features/article/presentation/screens/screens.dart';
import '../../../features/onboard/presentation/screens/splash_screen.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  // TODO: Add all routes here

  routes: <RouteBase>[
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const SplashScreen(),
    ),
    GoRoute(
      path: Routes.articleDetail,
      builder: (context, state) {
        final article = state.extra as Article;
        return ArticleScreen(article: article);
      },
    ),
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const ArticleFormScreen(),
    ),
  ],
);
