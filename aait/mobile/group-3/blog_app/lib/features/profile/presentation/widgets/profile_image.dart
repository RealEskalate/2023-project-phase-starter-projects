
import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ProfileImage extends StatelessWidget {
  final String imageName;
  final VoidCallback onChangeImage;
  final kInnerDecoration = BoxDecoration(
      color: whiteColor,
      border: Border.all(color: whiteColor),
      borderRadius: BorderRadius.circular(24));
  final kOuterDecoration = BoxDecoration(
      gradient: LinearGradient(
          colors: [blue, lightBlue,aqua]),
      borderRadius: BorderRadius.circular(24));

  ProfileImage({super.key, required this.imageName, required this.onChangeImage});
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: onChangeImage,
      child: Container(
        width: 84.w,
        height: 84.h,
        child: Padding(
          padding: EdgeInsets.symmetric(horizontal: 2.w, vertical: 2.h),
          child: Container(
            alignment: Alignment.center,
            child: ClipRRect(
              borderRadius: BorderRadius.circular(24),
              child: Image.network(
                imageName,
                width: 66.71.w,
                height: 66.71.h,
                fit: BoxFit.cover,
              ),
            ),
            decoration: kInnerDecoration,
          ),
        ),
        decoration: kOuterDecoration,
      ),
    );
  }
}