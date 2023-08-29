import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class UserInfo extends StatelessWidget {
  final String authorImageUrl;
  final String postedAt;
  final String authorName;
  const UserInfo({
    required this.authorImageUrl,
    required this.postedAt,
    required this.authorName,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Container(
                height: 38.h,
                width: 38.w,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(12.r),
                  image: DecorationImage(
                    image: NetworkImage(
                      authorImageUrl,
                    ),
                    fit: BoxFit.cover,
                  ),
                ),
              ),
              SizedBox(width: 16.w),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  TextButton(
                    onPressed: () {},
                    style: TextButton.styleFrom(
                      padding: EdgeInsets.zero,
                      // minimumSize: Size(50, 30),
                      tapTargetSize: MaterialTapTargetSize.shrinkWrap,
                    ),
                    child: Text(
                      authorName,
                      style: GoogleFonts.urbanist(
                        fontSize: 14.sp,
                        fontWeight: FontWeight.w500,
                        color: darkBlueText,
                      ),
                    ),
                  ),
                  // SizedBox(height: 6.h),
                  Text(
                    postedAt,
                    style: GoogleFonts.poppins(
                      fontSize: 12.sp,
                      fontWeight: FontWeight.w900,
                      color: darkGrey,
                    ),
                  ),
                ],
              )
            ],
          ),
          IconButton(
              onPressed: () {},
              icon: Icon(
                Icons.bookmark_border,
                size: 24.sp,
                color: blue,
              ))
        ],
      ),
    );
  }
}