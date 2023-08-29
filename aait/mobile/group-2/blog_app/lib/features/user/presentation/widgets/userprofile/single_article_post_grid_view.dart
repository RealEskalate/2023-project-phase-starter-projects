import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class SingleArticlePostGridView extends StatelessWidget {
  final String imageUrl, articleTitle, articleSubTitle, likes;
  final double timeSincePosted;

  const SingleArticlePostGridView({
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

    double imageWidth = double.infinity;
    double imageHeight = 150.w;
    double titleFontSize = 14.sp;
    double subTitleFontSize = 14.sp;
    double statsFontSize = 12.sp;
    double iconSize = 14.w;
    double statsSpacing = 4.w;

    return Card(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(16.0),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: imageWidth,
            height: imageHeight,
            child: ClipRRect(
              borderRadius: BorderRadius.circular(16),
              child: Image.network(
                imageUrl,
                fit: BoxFit.cover,
              ),
            ),
          ),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                articleTitle,
                style: TextStyle(
                  fontWeight: FontWeight.w100,
                  fontSize: titleFontSize,
                  color: Color(0xFF376AED),
                ),
              ),
              SizedBox(height: statsSpacing),
              Text(
                articleSubTitle,
                style: TextStyle(
                  fontWeight: FontWeight.w500,
                  fontSize: subTitleFontSize,
                  color: Color(0xFF0D253C),
                ),
              ),
              SizedBox(height: 8.w),
              Row(
                children: [
                  Row(
                    children: [
                      Icon(
                        Icons.thumb_up_alt_outlined,
                        color: Color(0xFF2D4379),
                        size: iconSize,
                      ),
                      SizedBox(width: statsSpacing),
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
                  Spacer(),
                  Row(
                    children: [
                      Icon(
                        Icons.access_time,
                        color: Color(0xFF2D4379),
                        size: iconSize,
                      ),
                      SizedBox(width: statsSpacing),
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
                  SizedBox(width: statsSpacing),
                  Icon(
                    Icons.bookmark_outlined,
                    color: Color(0xFF376AED),
                    size: iconSize,
                  ),
                ],
              ),
            ],
          ),
        ],
      ),
    );
  }
}
