import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class ArticleContentTextField extends StatelessWidget {
  const ArticleContentTextField({
    super.key,
    required this.controller,
  });

  final TextEditingController controller;
  @override
  Widget build(BuildContext context) {
    return Container(
      height: 375.h,
      padding: EdgeInsets.symmetric(horizontal: 21.w),
      decoration: BoxDecoration(
          color: fieldFillColor,
          border: Border.all(
            color: fieldBorderColor,
          ),
          borderRadius: BorderRadius.circular(10.r)),
      child: TextField(
        controller: controller,
        maxLines: null,
        decoration: InputDecoration(
          contentPadding:
              const EdgeInsets.only(top: 0, left: 0, bottom: 0, right: 0),
          filled: true,
          fillColor: fieldFillColor,
          border: InputBorder.none,
          hintText: "Article Content",
          hintStyle: GoogleFonts.poppins(
            fontSize: 11.sp,
            fontWeight: FontWeight.w200,
          ),
        ),
      ),
    );
  }
}
