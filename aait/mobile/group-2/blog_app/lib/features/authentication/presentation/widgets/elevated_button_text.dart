import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class ElevatedButtonText extends StatelessWidget {
  const ElevatedButtonText({
    super.key,
    this.text = 'SIGN UP',
  });

  final String text;

  @override
  Widget build(BuildContext context) {
    return Text(
      text,
      style: TextStyle(
          fontSize: 18.sp, fontFamily: 'UrbanistBold', color: AppColors.white),
    );
  }
}
