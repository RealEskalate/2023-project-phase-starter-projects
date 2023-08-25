import 'package:blog_app/features/user/presentation/widgets/userprofile/single_article_post_list_view.dart';
import 'package:flutter/material.dart';

import 'article_grid_view.dart';

class ArticleListView extends StatelessWidget {
  final List<ArticleData> articles;

  const ArticleListView({Key? key, required this.articles}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
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
    );
  }
}
