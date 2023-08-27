import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ShowPostsOrBookmarksButton extends StatelessWidget {
  final Color col;
  final String typeOfChoice;
  final int count;
  const ShowPostsOrBookmarksButton({
    super.key,
    required this.col,
    required this.typeOfChoice,
    required this.count,
  });

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    return Container(
      padding: EdgeInsets.only(top: 12.h),
      width: 115.w,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(12.0),
        color: col,
      ),
      child: Column(
        children: [
          Text(
            "$count",
            style: TextStyle(
              fontSize: 20.sp,
              fontWeight: FontWeight.w400,
              color: Colors.white,
            ),
          ),
          Text(
            typeOfChoice,
            style: TextStyle(
              fontSize: 12.sp,
              fontWeight: FontWeight.w400,
              color: Colors.white,
            ),
          ),
          SizedBox(height: 12.h),
        ],
      ),
    );
  }
}
