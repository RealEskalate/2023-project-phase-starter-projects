import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ArticleTitleBar extends StatelessWidget {
  final String title;

  const ArticleTitleBar({
    Key? key,
    required this.title,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double titleFontSize = 20.sp;
    double iconSize = 24.w;
    double iconSpacing = 12.w;

    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text(
          title,
          style: TextStyle(
            fontSize: titleFontSize,
            fontWeight: FontWeight.w500,
            color: Color(0xFF0D253C),
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Icon(
              Icons.grid_view,
              color: Color(0xFF376AED),
              size: iconSize,
            ),
            SizedBox(width: iconSpacing),
            Icon(
              Icons.list,
              color: Color(0xFF7B8BB2),
              size: iconSize,
            ),
          ],
        ),
      ],
    );
  }
}
