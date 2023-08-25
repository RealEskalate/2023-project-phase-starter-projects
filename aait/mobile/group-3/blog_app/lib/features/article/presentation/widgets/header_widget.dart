import 'package:blog_app/core/util/app_colors.dart'; // Importing app-specific colors
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class HeaderWidget extends StatelessWidget {
  const HeaderWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        GestureDetector(
          onTap: () {
            debugPrint("Sorted"); // Action when the sort icon is tapped
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
            style: Theme.of(context).textTheme.headlineLarge,
          ),
        ),
        Stack(
          alignment: Alignment.center,
          children: [
            const CircleAvatar(
              backgroundImage: AssetImage('images/avator.jpg'), // User's avatar
              radius: 32, // Avatar radius
            ),
            Container(
              width: 59,
              height: 59,
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
