import 'package:blog_app/features/user/presentation/widgets/userprofile/posts_bar.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/single_article_post_list_view.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'article_grid_view.dart';

class ArticleListView extends StatelessWidget {
  final List<ArticleData> articles;

  const ArticleListView({Key? key, required this.articles}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const ArticleTitleBar(title: "My Posts"),
        SizedBox(height: 27.h),
        ListView.builder(
          shrinkWrap: true,
          itemCount: articles.length,
          itemBuilder: (context, index) {
            return SingleArticlePostListView(
              imageUrl: articles[index].imageUrl,
              articleTitle: articles[index].articleTitle,
              articleSubTitle: articles[index].articleSubTitle,
              likes: articles[index].likes,
              timeSincePosted: articles[index].timeSincePosted,
            );
          },
        ),
      ],
    );
  }
}
