import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../article/domain/entities/article.dart';
import 'posts_bar.dart';
import 'single_article_post_grid_view.dart';

class ArticleGridView extends StatelessWidget {
  final List<Article> articles;
  final VoidCallback? onGridView;
  final VoidCallback? onListView;

  const ArticleGridView(
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

class ArticleData {
  final String imageUrl;
  final String articleTitle;
  final String articleSubTitle;
  final String likes;
  final double timeSincePosted;

  ArticleData({
    required this.imageUrl,
    required this.articleTitle,
    required this.articleSubTitle,
    required this.likes,
    required this.timeSincePosted,
  });
}
