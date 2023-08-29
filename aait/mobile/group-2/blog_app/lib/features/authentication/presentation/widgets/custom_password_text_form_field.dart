import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomPasswordTextField extends StatefulWidget {
  const CustomPasswordTextField({
    Key? key,
    required this.passwordController,
  }) : super(key: key);

  final TextEditingController passwordController;

  @override
  State<CustomPasswordTextField> createState() =>
      _CustomPasswordTextFieldState();
}

class _CustomPasswordTextFieldState extends State<CustomPasswordTextField> {
  bool _isObscureText = true;
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 66.h,
      child: TextFormField(
        keyboardType: TextInputType.visiblePassword,
        controller: widget.passwordController,
        obscureText: _isObscureText,
        decoration: InputDecoration(
          labelText: 'Password',
          labelStyle: TextStyle(
            fontSize: 14.sp,
            fontFamily: 'UrbanistItalicThin',
            color: AppColors.darkBlue,
          ),
          contentPadding: EdgeInsets.only(top: 5.h, bottom: 5.h),
          floatingLabelBehavior: FloatingLabelBehavior.always,
          suffixIcon: TextButton(
            onPressed: () {
              setState(() {
                _isObscureText = !_isObscureText;
              });
            },
            child: Text(
              _isObscureText ? 'Show' : 'Hide',
              style: TextStyle(
                fontSize: 14.sp,
                fontFamily: 'UrbanistMedium',
                color: _isObscureText
                    ? AppColors.blue
                    : AppColors.red.withOpacity(0.5),
              ),
            ),
          ),
        ),
        style: TextStyle(
          fontSize: 16.sp,
          fontFamily: 'UrbanistMedium',
          color: AppColors.darkerBlue,
        ),
        validator: (value) {
          if (value == null || value.isEmpty) {
            return 'Please enter your password';
          } else if (value.length < 6 || value.length > 16) {
            return 'Password must be between 6 and 16 characters';
          }
          return null;
        },
        autovalidateMode: AutovalidateMode.onUserInteraction,
      ),
    );
  }
}
