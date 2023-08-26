import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ForgotPassword extends StatelessWidget {
  const ForgotPassword({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          'Forgot your password?',
          style: TextStyle(
            fontSize: 14.sp,
            fontFamily: 'PoppinsBlack',
            color: const Color(0xFF2D4379),
          ),
        ),
        TextButton(
          onPressed: () {},
          child: Text(
            'Reset here',
            style: TextStyle(
              fontSize: 14.sp,
              fontFamily: 'UrbanistMedium',
              color: const Color(0xFF376AED),
            ),
          ),
        ),
      ],
    );
  }
}
