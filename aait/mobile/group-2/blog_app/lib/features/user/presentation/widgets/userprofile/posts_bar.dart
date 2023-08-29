import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../../core/presentation/theme/app_colors.dart';

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
            color: AppColors.darkerBlue,
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            GestureDetector(
              onTap: () {},
              child: Icon(
                Icons.grid_view,
                color: AppColors.blue,
                size: iconSize,
              ),
            ),
            SizedBox(width: iconSpacing),
            GestureDetector(
              onTap: () {},
              child: Icon(
                Icons.list,
                color: AppColors.darkGray,
                size: iconSize,
              ),
            ),
          ],
        ),
      ],
    );
  }
}
