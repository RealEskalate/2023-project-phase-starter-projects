import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class WhiteGradientOverlay extends StatelessWidget {
  const WhiteGradientOverlay({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 116.h,
      decoration: BoxDecoration(
          gradient: LinearGradient(
              begin: Alignment.topCenter,
              end: Alignment.bottomCenter,
              colors: [
            Colors.white.withOpacity(0),
            Colors.white.withOpacity(1),
          ])),
    );
  }
}
