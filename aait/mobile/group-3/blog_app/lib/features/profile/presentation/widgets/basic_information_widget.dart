
import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BasicInformationWidget extends StatelessWidget {
  final String username;
  final String fullName;
  final String occupation;

  const BasicInformationWidget(
      {super.key,
      required this.username,
      required this.fullName,
      required this.occupation});
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(
          this.username,
          style: TextStyle(
              fontWeight: FontWeight.w900,
              fontSize: 14,
              color: darkBlueText),
        ),
        Text(
          this.fullName,
          style: TextStyle(fontWeight: FontWeight.w100, fontSize: 18.sp),
        ),
        SizedBox(
          height: 11.h,
        ),
        Text(
          this.occupation,
          style: TextStyle(
              fontWeight: FontWeight.w100,
              fontSize: 16,
              color: blue),
        )
      ],
    );
  }
}