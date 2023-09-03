import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class FormSubmitButton extends StatelessWidget {
  final VoidCallback onSumbit;
  const FormSubmitButton({
    super.key,
    required this.onSumbit,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        ElevatedButton(
          onPressed: onSumbit,
          style: ElevatedButton.styleFrom(
            padding: EdgeInsets.symmetric(horizontal: 26.w, vertical: 6.h),
            fixedSize: Size(108.w, 36.h),
            shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(21.r)),
            backgroundColor: blue,
            foregroundColor: Colors.white,
            textStyle: GoogleFonts.poppins(
              fontSize: 15.sp,
              fontWeight: FontWeight.w500,
            ),
          ),
          child: const Text("Publish"),
        ),
      ],
    );
  }
}
