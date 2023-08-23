
import 'package:flutter/material.dart';

import '../../domain/entity/article.dart';
import 'article_info_widget.dart';

class ListViewArticleCard extends StatelessWidget {
  final Article article;

  const ListViewArticleCard({super.key, required this.article});
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: 295,
          alignment: Alignment.center,
          child: Card(
            shape:
                RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
            elevation: 3,
            child: Row(
              children: [
                ClipRRect(
                    borderRadius: BorderRadius.circular(20),
                    child: Image.network(
                      article.image,
                      width: 92,
                      height: 141,
                      fit: BoxFit.cover,
                    )),
                SizedBox(
                  width: 20,
                ),
                ArticleInfoWidget(
                  article: article,
                  needSpace: true,
                  heightBetweenIcons: 21,
                  needsPadding: false,
                )
              ],
            ),
          ),
        ),
        SizedBox(
          height: 6,
        )
      ],
    );
  }
}