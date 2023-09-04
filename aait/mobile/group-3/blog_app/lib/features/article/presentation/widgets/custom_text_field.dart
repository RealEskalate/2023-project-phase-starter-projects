import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class CustomTextField extends StatelessWidget {
  const CustomTextField({
    super.key,
    required this.hint,
    required this.controller,
  });
  final String hint;
  final TextEditingController controller;
  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        enabledBorder: UnderlineInputBorder(
            borderSide: BorderSide(color: fieldBorderColor, width: 3.42.h)),
        focusedBorder: UnderlineInputBorder(
            borderSide: BorderSide(color: darkGrey, width: 3.42.h)),
        hintText: hint,
        hintStyle: GoogleFonts.poppins(
          fontSize: 19.sp,
          fontWeight: FontWeight.w200,
          color: hintTextColor,
        ),
      ),
    );
  }
}
