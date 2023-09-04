import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class PostText extends StatelessWidget {
  final String postText;
  const PostText({
    required this.postText,
    super.key,
  });
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 23.w),
      child: Text(
        postText,
        style: GoogleFonts.poppins(
          fontSize: 16.sp,
          fontWeight: FontWeight.w400,
          color: darkBlueText,
        ),
        textAlign: TextAlign.start,
      ),
    );
  }
}
