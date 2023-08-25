import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../domain/entity/article.dart';
import 'article_info_widget.dart';

class GridViewArticleCard extends StatelessWidget {
  final Article article;
  final bool isBookmarked;
  const GridViewArticleCard(
      {super.key, required this.article, required this.isBookmarked});
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 10.w),
      child: Card(
        shape:
            RoundedRectangleBorder(borderRadius: BorderRadius.circular(20.r)),
        elevation: 3,
        child: Column(
          children: [
            ClipRRect(
              borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(20.r),
                  topRight: Radius.circular(20.r)),
              child: Image.network(
                article.image,
                width: 190.w,
                height: 75.h,
                fit: BoxFit.cover,
              ),
            ),
            SizedBox(
              height: 4.h,
            ),
            ArticleInfoWidget(
              isBookmarked: isBookmarked,
              article: article,
              needSpace: false,
              heightBetweenIcons: 4,
              needsPadding: true,
            ),
          ],
        ),
      ),
    );
  }
}
