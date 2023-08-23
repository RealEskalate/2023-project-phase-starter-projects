
import 'package:flutter/material.dart';

import '../../domain/entity/article.dart';
import 'article_icon_button.dart';

class ArticleInfoWidget extends StatelessWidget {
  const ArticleInfoWidget(
      {super.key,
      required this.article,
      required this.needSpace,
      required this.heightBetweenIcons,
      required this.needsPadding});

  final Article article;
  final bool needSpace;
  final double heightBetweenIcons;
  final bool needsPadding;

  @override
  Widget build(BuildContext context) {
    final initalSpace = this.needSpace
        ? SizedBox(
            height: 20,
          )
        : SizedBox();
    final paddingSize = this.needsPadding
        ? EdgeInsets.symmetric(horizontal: 10)
        : EdgeInsets.zero;
    return Expanded(
      child: Container(
        padding: paddingSize,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            initalSpace,
            Text(
              article.title,
              style: TextStyle(
                  color: Color(0xFF376AED),
                  fontWeight: FontWeight.w100,
                  fontSize: 14),
            ),
            SizedBox(
              height: 4,
            ),
            Text(
              article.subTitle,
              style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
            ),
            SizedBox(
              height: heightBetweenIcons,
            ),
            Row(
              children: [
                ArticleIconButton(
                    textValue: article.formatDate(), icon: Icons.access_time),
                SizedBox(
                  width: 4,
                ),
                IconButton(
                  onPressed: null,
                  icon: Icon(Icons.bookmark_outline),
                  iconSize: 16,
                )
              ],
            ),
          ],
        ),
      ),
    );
  }
}