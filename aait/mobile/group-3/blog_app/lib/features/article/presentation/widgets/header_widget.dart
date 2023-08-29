import 'package:blog_app/core/util/app_colors.dart'; // Importing app-specific colors
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

class HeaderWidget extends StatefulWidget {
  const HeaderWidget({super.key});

  @override
  State<HeaderWidget> createState() => _HeaderWidgetState();
}

class _HeaderWidgetState extends State<HeaderWidget> {
  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        GestureDetector(
          onTap: () {
            Navigator.pushNamed(context, '/profile');
          },
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
            InkWell(
              onTap: () {
                setState(() {
                  context.go('/profile');
                  print("Here I am being pressed");
                });
              },
              child: CircleAvatar(
                backgroundImage: const AssetImage(
                    'assets/images/onboarding2.jpg'), // User's avatar
                radius: 28.sp, // Avatar radius
              ),
            ),
            Container(
              width: 65.w,
              height: 65.h,
              decoration: BoxDecoration(
                shape: BoxShape.circle,
                border: Border.all(
                  color: AppColors
                      .whiteColor, // Color of the border around the avatar
                  width: 2.sp, // Border width
                ),
              ),
            ),
          ],
        ),
      ],
    );
  }
}
