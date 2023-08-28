import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_theme.dart';

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
          style: AppTheme.themeData.textTheme.displayMedium,
        ),
        SizedBox(
          height: 16.h,
        ),
        Text(
          onBoardDescription,
          textAlign: TextAlign.left,
          style: AppTheme.themeData.textTheme.displayLarge,
        ),
      ],
    );
  }
}
