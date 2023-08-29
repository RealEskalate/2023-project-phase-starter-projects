import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

Widget buildContent(String title, String description) {
  return Column(
    children: [
      SizedBox(height: ScreenUtil().setHeight(32)),
      Container(
        padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
        child: Text(
          title,
          style: TextStyle(
            fontSize: 24.sp,
            fontFamily: 'Urbanist',
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.w100,
            color: darkBlue,
          ),
        ),
      ),
      SizedBox(height: ScreenUtil().setHeight(16)),
      Container(
        padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
        child: Text(
          description,
          style: TextStyle(
            fontWeight: FontWeight.w900,
            fontFamily: 'Poppins',
            fontSize: 14.sp,
            color: darkBlueText,
          ),
        ),
      ),
      SizedBox(height: ScreenUtil().setHeight(10)),
    ],
  );
}