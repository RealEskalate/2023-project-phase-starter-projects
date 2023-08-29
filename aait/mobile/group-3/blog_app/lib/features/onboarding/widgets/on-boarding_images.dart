import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class OnboardingImagesWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: ScreenUtil().setWidth(40),
      ),
      height: ScreenUtil().setHeight(332),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            children: [
              OnboardingImage(
                imagePath: "assets/images/onboarding1.jpg",
                width: 92,
              ),
              SizedBox(
                width: ScreenUtil().setWidth(10),
              ),
              OnboardingImage(
                imagePath: "assets/images/onboarding2.jpg",
                width: 180,
              ),
            ],
          ),
          SizedBox(height: 10.h),
          Row(
            children: [
              OnboardingImage(
                imagePath: "assets/images/onboarding3.jpg",
                width: 180,
              ),
              SizedBox(
                width: ScreenUtil().setWidth(10),
              ),
              OnboardingImage(
                imagePath: "assets/images/onboarding4.jpg",
                width: 92,
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class OnboardingImage extends StatelessWidget {
  final String imagePath;
  final double width;

  const OnboardingImage({
    required this.imagePath,
    required this.width,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: ScreenUtil().setHeight(157),
      width: ScreenUtil().setWidth(width),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(24),
      ),
      child: ClipRRect(
        borderRadius: BorderRadius.circular(24),
        child: Image.asset(
          imagePath,
          fit: BoxFit.cover,
        ),
      ),
    );
  }
}