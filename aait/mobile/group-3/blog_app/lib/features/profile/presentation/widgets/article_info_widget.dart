import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/util/value_converter.dart';
import '../../domain/entity/article.dart';
import 'article_icon_button.dart';

class ArticleInfoWidget extends StatelessWidget {
  ArticleInfoWidget(
      {super.key,
      required this.article,
      required this.needSpace,
      required this.heightBetweenIcons,
      required this.needsPadding});

  final Article article;
  final bool needSpace;
  final double heightBetweenIcons;
  final bool needsPadding;
  final ValueConverter valueConverter = ValueConverter();

  @override
  Widget build(BuildContext context) {
    final initalSpace = this.needSpace
        ? SizedBox(
            height: 20.h,
          )
        : SizedBox();
    final paddingSize = this.needsPadding
        ? EdgeInsets.symmetric(horizontal: 10.w)
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
                  color: blue,
                  fontWeight: FontWeight.w100,
                  fontSize: 14),
            ),
            SizedBox(
              height: 4.h,
            ),
            Text(
              article.subTitle,
              style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14.sp),
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
            ),
            SizedBox(height: heightBetweenIcons.h),
            Row(
              children: [
                ArticleIconButton(
                    textValue: valueConverter.formatDate(article.createdAt),
                    icon: Icons.access_time),
                SizedBox(
                  width: 4.w,
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
