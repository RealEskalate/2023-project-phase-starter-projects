import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ShowWelcomeText extends StatelessWidget {
  const ShowWelcomeText(
      {super.key,
      this.welcomeMessage = 'Welcome Back!',
      this.authMessage = 'Sign in with your account'});

  final String welcomeMessage;
  final String authMessage;

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(welcomeMessage,
            style: TextStyle(
                fontSize: 24.sp,
                fontFamily: 'UrbanistSemiBold',
                color: const Color(0xFF0D253C))),
        SizedBox(height: 20.h),
        Text(
          authMessage,
          style: TextStyle(
            fontSize: 14.sp,
            fontFamily: 'PoppinsBlack',
            color: const Color(0xFF2D4379),
          ),
        ),
      ],
    );
  }
}
