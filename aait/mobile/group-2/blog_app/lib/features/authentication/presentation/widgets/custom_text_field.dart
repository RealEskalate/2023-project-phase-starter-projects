import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomTextFormField extends StatelessWidget {
  const CustomTextFormField({
    super.key,
    required TextEditingController controller,
    required this.labelText,
  }) : _controller = controller;

  final TextEditingController _controller;
  final String labelText;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 66.h,
      child: TextFormField(
        keyboardType: TextInputType.emailAddress,
        controller: _controller,
        decoration: InputDecoration(
            labelText: labelText,
            labelStyle: TextStyle(
              fontSize: 14.sp,
              fontFamily: 'UrbanistItalicThin',
              color: AppColors.darkBlue,
            ),
            contentPadding: EdgeInsets.only(top: 5.h, bottom: 5.h),
            floatingLabelBehavior: FloatingLabelBehavior.always),
        style: TextStyle(
          fontSize: 16.sp,
          fontFamily: 'UrbanistMedium',
          color: AppColors.darkerBlue,
        ),
      ),
    );
  }
}
