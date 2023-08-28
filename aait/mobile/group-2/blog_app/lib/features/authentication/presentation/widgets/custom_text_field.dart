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

  // method to validate email
  bool isValidEmail(String email) {
    return RegExp(r'^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z]+').hasMatch(email);
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 66.h,
      child: TextFormField(
        keyboardType: labelText == 'Username'
            ? TextInputType.emailAddress
            : TextInputType.text,
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
        validator: (value) {
          if (value == null || value.isEmpty) {
            return 'Please enter $labelText';
          } else if (labelText.trim() == 'Username' && !isValidEmail(value)) {
            return 'Please enter a valid email';
          } else if (labelText.trim() == 'Short Bio' &&
              (value.length < 25 || value.length > 150)) {
            return 'Bio must be between 25 and 150 characters';
          } else if (labelText.trim() == 'Expertise' &&
              (value.length < 5 || value.length > 50)) {
            return 'Expertise must be between 5 and 50 characters';
          }
          return null;
        },
        autovalidateMode: AutovalidateMode.onUserInteraction,
      ),
    );
  }
}
