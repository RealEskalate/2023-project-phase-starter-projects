import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../article/domain/entities/article.dart';
import 'posts_bar.dart';
import 'single_article_post_list_view.dart';

class ArticleListView extends StatelessWidget {
  final List<Article> articles;
  final String title;

  const ArticleListView({
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
        ListView.builder(
          shrinkWrap: true,
          itemCount: articles.length,
          itemBuilder: (context, index) {
            return SingleArticlePostListView(
              article: articles[index],
            );
          },
        ),
      ],
    );
  }
}
