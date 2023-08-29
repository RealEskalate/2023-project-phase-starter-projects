import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../article/domain/entities/article.dart';
import 'article_grid_view.dart';
import 'posts_bar.dart';
import 'single_article_post_list_view.dart';

class ArticleListView extends StatelessWidget {
  final VoidCallback? onGridView;
  final VoidCallback? onListView;
  final List<Article> articles;

  const ArticleListView(
      {Key? key, required this.articles, this.onGridView, this.onListView})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        ArticleTitleBar(
          title: "My Posts",
          onGridView: onGridView,
          onListView: onListView,
        ),
        SizedBox(height: 27.h),
        ListView.builder(
          shrinkWrap: true,
          itemCount: articles.length,
          itemBuilder: (context, index) {
            return SingleArticlePostListView(
              imageUrl: articles[index].photoUrl,
              articleTitle: articles[index].title,
              articleSubTitle: articles[index].subTitle,
              likes: '2.1k',
              timeSincePosted: 1,
            );
          },
        ),
      ],
    );
  }
}
