import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

Widget buildContent(String title, String description) {
  return Column(
    children: [
      SizedBox(height: ScreenUtil().setHeight(15)),
      Container(
        padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
        child: Text(
          title,
          style: TextStyle(
            fontSize: 20.sp,
            fontWeight: FontWeight.w100,
            color: Color(0xFF0D253C),
          ),
        ),
      ),
      SizedBox(height: ScreenUtil().setHeight(5)),
      Container(
        padding: EdgeInsets.symmetric(horizontal: ScreenUtil().setWidth(40)),
        child: Text(
          description,
          style: TextStyle(
            fontWeight: FontWeight.w900,
            fontSize: 14.sp,
            color: Color(0xFF2D4379),
          ),
        ),
      ),
      SizedBox(height: ScreenUtil().setHeight(10)),
    ],
  );
}