import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class OnBoardingWidget extends StatelessWidget {
  final String onBoardHeader;
  final String onBoardDescription;

  const OnBoardingWidget(
      {required this.onBoardHeader,
      required this.onBoardDescription,
      super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(
          onBoardHeader,
          textAlign: TextAlign.left,
        ),
        SizedBox(
          height: 16.h,
        ),
        Text(
          onBoardDescription,
          textAlign: TextAlign.left,
        ),
      ],
    );
  }
}
