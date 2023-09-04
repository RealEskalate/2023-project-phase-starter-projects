import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../../core/presentation/theme/app_colors.dart';

class ProfileBar extends StatelessWidget {
  const ProfileBar({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double marginHorizontal = 40.w;
    double marginTop = 24.h;
    double fontSize = 24.sp;
    double iconSize = 24.w;

    return Container(
      margin:
          EdgeInsets.fromLTRB(marginHorizontal, marginTop, marginHorizontal, 0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            'Profile',
            style: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.w500,
              color: AppColors.darkerBlue,
            ),
          ),
          GestureDetector(
            child: Icon(
              Icons.more_horiz,
              color: AppColors.darkerBlue,
              size: iconSize,
            ),
          )
        ],
      ),
    );
  }
}
