import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class PostImage extends StatelessWidget {
  const PostImage({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.only(
          topLeft: Radius.circular(28.r), topRight: Radius.circular(28.r)),
      child: Image.asset(
        "assets/images/postPic.jpg",
        width: double.infinity,
      ),
    );
  }
}