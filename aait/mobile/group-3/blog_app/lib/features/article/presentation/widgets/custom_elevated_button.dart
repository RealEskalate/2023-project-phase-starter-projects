import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/image_sheet.dart';

class CustomElevatedLikeButton extends StatelessWidget {
  final String likeCount;
  const CustomElevatedLikeButton({
    super.key,
    required this.likeCount,
  });

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: () async {
        await ImageSheet().show(context);
      },
      style: ElevatedButton.styleFrom(
          padding: EdgeInsets.symmetric(horizontal: 24.w, vertical: 12.h),
          backgroundColor: blue,
          foregroundColor: Colors.white,
          textStyle: GoogleFonts.urbanist(
            fontSize: 16.sp,
            fontWeight: FontWeight.w500,
          ),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(12),
          )),
      child: Row(
        children: [
          const Icon(Icons.thumb_up_outlined),
          SizedBox(width: 8.w),
          Text(likeCount),
        ],
      ),
    );
  }
}
