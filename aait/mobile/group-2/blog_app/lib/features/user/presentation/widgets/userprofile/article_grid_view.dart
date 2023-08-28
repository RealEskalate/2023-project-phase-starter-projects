import 'package:blog_app/features/user/presentation/widgets/userprofile/posts_bar.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/single_article_post_grid_view.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ArticleGridView extends StatelessWidget {
  final List<ArticleData> articles;

  const ArticleGridView({Key? key, required this.articles}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        const ArticleTitleBar(title: "My Bookmarks"),
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
