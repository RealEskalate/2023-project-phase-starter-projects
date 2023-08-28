import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

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
            color: const Color(0xFF2D4379),
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
                color:
                    _isObscureText ? const Color(0xFF376AED) : Colors.red[300],
              ),
            ),
          ),
        ),
        style: TextStyle(
          fontSize: 16.sp,
          fontFamily: 'UrbanistMedium',
          color: const Color(0xFF0D253C),
        ),
      ),
    );
  }
}
