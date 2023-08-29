import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

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
            "Profile",
            style: TextStyle(
              fontSize: fontSize,
              fontWeight: FontWeight.w500,
              color: Color(0xFF0D253C),
            ),
          ),
          GestureDetector(
            child: Icon(
              Icons.more_horiz,
              color: Color(0xFF0D253C),
              size: iconSize,
            ),
          )
        ],
      ),
    );
  }
}
