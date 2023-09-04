import 'package:blog_app/core/util/app_colors.dart'; // Importing app-specific colors
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class HeaderWidget extends StatelessWidget {
  final VoidCallback callback;
  
  const HeaderWidget({required this.callback, super.key,});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        GestureDetector(
          child: Icon(
            Icons.sort,
            size: 40.sp,
            color: AppColors.textDark, // Color of the sort icon
          ),
        ),
        Center(
          child: Text(
            "Welcome Back!", // Greeting text for the user
            style: TextStyle(
              fontFamily: 'Poppins-SemiBold',
              fontSize: 27.sp,
              fontWeight: FontWeight.w600,
              color: AppColors.textDark,
            ),
          ),
        ),
        Stack(
          alignment: Alignment.center,
          children: [
            GestureDetector(
              onTap: callback,
              child: CircleAvatar(
                backgroundImage: const AssetImage(
                    'assets/images/avator.jpg'), // User's avatar
                radius: 28.sp, // Avatar radius
              ),
            ),
            GestureDetector(
              onTap: callback,
              child: Container(
                width: 55.w,
                height: 55.h,
                decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  border: Border.all(
                    color: AppColors
                        .whiteColor, // Color of the border around the avatar
                    width: 2.sp, // Border width
                  ),
                ),
              ),
            ),
          ],
        ),
      ],
    );
  }
}
