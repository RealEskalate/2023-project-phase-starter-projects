import 'package:go_router/go_router.dart';

import '../../../features/article/presentation/screens/screens.dart';
import 'routes.dart';

final GoRouter router = GoRouter(
  // TODO: Add all routes here

  routes: <RouteBase>[
    GoRoute(
      path: Routes.home,
      builder: (context, state) => const ArticleScreen(articleId: '1'),
    ),
    GoRoute(
      path: Routes.articleDetail,
      builder: (context, state) => const ArticleScreen(articleId: '1'),
    ),
    GoRoute(
      path: Routes.createArticle,
      builder: (context, state) => const ArticleFormScreen(),
    ),
  ],
);
