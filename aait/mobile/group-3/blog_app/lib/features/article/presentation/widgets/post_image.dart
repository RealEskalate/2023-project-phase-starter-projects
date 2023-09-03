import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class PostImage extends StatelessWidget {
  final String postImageUrl;
  const PostImage({
    required this.postImageUrl,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.only(
          topLeft: Radius.circular(28.r), topRight: Radius.circular(28.r)),
      child: Image.network(
        postImageUrl,
        width: double.infinity,
        fit: BoxFit.cover,
      ),
    );
  }
}
