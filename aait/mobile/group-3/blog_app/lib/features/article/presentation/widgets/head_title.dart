import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class HeadTitle extends StatelessWidget {
  const HeadTitle({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Text(
        "Four Things Everyone Needs To Know",
        style: GoogleFonts.poppins(
          fontWeight: FontWeight.w600,
          fontSize: 24.sp,
        ),
      ),
    );
  }
}