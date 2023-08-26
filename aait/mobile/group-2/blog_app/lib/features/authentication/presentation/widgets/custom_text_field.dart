import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

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
              color: const Color(0xFF2D4379),
            ),
            contentPadding: EdgeInsets.only(top: 5.h, bottom: 5.h),
            floatingLabelBehavior: FloatingLabelBehavior.always),
        style: TextStyle(
          fontSize: 16.sp,
          fontFamily: 'UrbanistMedium',
          color: const Color(0xFF0D253C),
        ),
      ),
    );
  }
}
