import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ButtonContainer extends StatelessWidget {
  final Color? color;
  final int numberValue;
  final String category;
  final VoidCallback onPressed;

  ButtonContainer(
      {super.key,
      this.color,
      required this.numberValue,
      required this.onPressed,
      required this.category});
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onPressed,
      child: Container(
        alignment: Alignment.center,
        width: 76.7.w,
        height: 68.h,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            color: color ?? Color(0xFF2151CD)),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              numberValue.toString(),
              textAlign: TextAlign.center,
              style: TextStyle(
                  color: whiteColor,
                  fontSize: 20,
                  fontWeight: FontWeight.w400),
            ),
            SizedBox(
              height: 4.h,
            ),
            Text(
              category,
              textAlign: TextAlign.center,
              style: TextStyle(
                  color: whiteColor,
                  fontSize: 12,
                  fontWeight: FontWeight.w100),
            )
          ],
        ),
      ),
    );
  }
}
