import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../domain/entity/article.dart';
import 'article_info_widget.dart';

class ListViewArticleCard extends StatelessWidget {
  final Article article;
  final bool isBookmarked;

  const ListViewArticleCard(
      {super.key, required this.article, required this.isBookmarked});
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        InkWell(
          onTap: () {
            context.push('/article', extra: article.id);
          },
          child: Container(
            width: 295.w,
            alignment: Alignment.center,
            child: Card(
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(20)),
              elevation: 3,
              child: Row(
                children: [
                  ClipRRect(
                      borderRadius: BorderRadius.circular(20),
                      child: Image.network(
                        article.image,
                        width: 92.w,
                        height: 141.h,
                        fit: BoxFit.cover,
                      )),
                  SizedBox(
                    width: 20,
                  ),
                  ArticleInfoWidget(
                    isBookmarked: isBookmarked,
                    article: article,
                    needSpace: true,
                    heightBetweenIcons: 21,
                    needsPadding: false,
                  )
                ],
              ),
            ),
          ),
        ),
        SizedBox(
          height: 6.h,
        )
      ],
    );
  }
}
