import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../../core/presentation/theme/app_colors.dart';

class SingleArticlePostListView extends StatelessWidget {
  final String imageUrl, articleTitle, articleSubTitle, likes;
  final double timeSincePosted;

  const SingleArticlePostListView({
    Key? key,
    required this.imageUrl,
    required this.articleTitle,
    required this.articleSubTitle,
    required this.likes,
    required this.timeSincePosted,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double cardPadding = 20.w;
    double borderRadius = 16;
    double imageWidth = 92.w;
    double imageHeight = 141.w;
    double spacing = 20.w;
    double titleFontSize = 14.sp;
    double subTitleFontSize = 14.sp;
    double statsFontSize = 12.sp;
    double iconSize = 24.w;
    double statsSpacing = 6.w;

    return Padding(
      padding: EdgeInsets.only(bottom: cardPadding),
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(borderRadius),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            SizedBox(
              width: imageWidth,
              height: imageHeight,
              child: ClipRRect(
                borderRadius: BorderRadius.circular(borderRadius),
                child: CachedNetworkImage(
                  imageUrl: imageUrl,
                  fit: BoxFit.cover,
                ),
              ),
            ),
            SizedBox(width: spacing),
            Expanded(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    articleTitle,
                    style: TextStyle(
                      fontWeight: FontWeight.w100,
                      fontSize: titleFontSize,
                      color: AppColors.blue,
                    ),
                  ),
                  SizedBox(height: statsSpacing),
                  Text(
                    articleSubTitle,
                    style: TextStyle(
                      fontWeight: FontWeight.w500,
                      fontSize: subTitleFontSize,
                      color: AppColors.darkerBlue,
                    ),
                  ),
                  SizedBox(height: statsSpacing * 3),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          Icon(
                            Icons.thumb_up_alt_outlined,
                            color: Color(0xFF2D4379),
                            size: iconSize,
                          ),
                          SizedBox(
                            width: statsSpacing,
                          ),
                          Text(
                            likes,
                            style: TextStyle(
                              fontSize: statsFontSize,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ],
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          Icon(
                            Icons.access_time,
                            color: Color(0xFF2D4379),
                            size: iconSize,
                          ),
                          SizedBox(
                            width: statsSpacing,
                          ),
                          Text(
                            "$timeSincePosted hr ago",
                            style: TextStyle(
                              fontSize: statsFontSize,
                              fontWeight: FontWeight.w500,
                              color: Color(0xFF2D4379),
                            ),
                          ),
                        ],
                      ),
                      Icon(
                        Icons.bookmark_outlined,
                        color: AppColors.blue,
                        size: iconSize,
                      ),
                    ],
                  )
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
