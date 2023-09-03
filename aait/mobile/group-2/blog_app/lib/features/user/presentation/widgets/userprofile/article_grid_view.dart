import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../article/domain/entities/article.dart';
import 'posts_bar.dart';
import 'single_article_post_grid_view.dart';

class ArticleGridView extends StatelessWidget {
  final List<Article> articles;
  final String title;

  const ArticleGridView({
    Key? key,
    required this.articles,
    required this.title,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        ArticleTitleBar(
          title: title,
        ),
        SizedBox(height: 27.h),
        GridView.builder(
          shrinkWrap: true,
          gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
            mainAxisSpacing: 20,
            crossAxisSpacing: 20,
            childAspectRatio: 0.6,
          ),
          itemCount: articles.length,
          itemBuilder: (context, index) {
            return SingleArticlePostGridView(
              article: articles[index],
            );
          },
        ),
      ],
    );
  }
}
