import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

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
                color: AppColors.darkerBlue)),
        SizedBox(height: 20.h),
        Text(
          authMessage,
          style: TextStyle(
            fontSize: 14.sp,
            fontFamily: 'PoppinsBlack',
            color: AppColors.darkBlue,
          ),
        ),
      ],
    );
  }
}
