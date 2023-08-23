
import 'package:flutter/material.dart';

import '../../domain/entity/article.dart';
import 'article_info_widget.dart';

class GridViewArticleCard extends StatelessWidget {
  final Article article;

  const GridViewArticleCard({super.key, required this.article});
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 10),
      child: Card(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        elevation: 3,
        child: Column(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(20), topRight: Radius.circular(20)),
              child: Image.network(
                article.image,
                width: 190,
                height: 75,
                fit: BoxFit.cover,
              ),
            ),
            SizedBox(
              height: 4,
            ),
            ArticleInfoWidget(
                article: article, needSpace: false, heightBetweenIcons: 4, needsPadding: true,),
          ],
        ),
      ),
    );
  }
}