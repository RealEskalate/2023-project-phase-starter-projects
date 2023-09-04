import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

class HeadTitle extends StatelessWidget {
  final String headTitle;
  const HeadTitle({
    super.key,
    required this.headTitle,
  });
  @override
  Widget build(BuildContext context) {
    return Align(
      alignment: Alignment.centerLeft,
      child: Padding(
        padding: EdgeInsets.symmetric(horizontal: 40.w),
        
        child: Text(
          headTitle,
          style: GoogleFonts.poppins(
            fontWeight: FontWeight.w600,
            fontSize: 24.sp,
            
          ),
        ),
      ),
    );
  }
}
