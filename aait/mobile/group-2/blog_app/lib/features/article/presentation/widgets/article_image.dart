import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ArticleImage extends StatelessWidget {
  final String imageUrl;

  const ArticleImage({super.key, required this.imageUrl});

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: const BorderRadius.only(
        topLeft: Radius.circular(45),
        topRight: Radius.circular(45),
      ),
      child: CachedNetworkImage(
        height: 300.h,
        width: 428.w,
        fit: BoxFit.cover,
        imageUrl: imageUrl,
      ),
    );
  }
}
