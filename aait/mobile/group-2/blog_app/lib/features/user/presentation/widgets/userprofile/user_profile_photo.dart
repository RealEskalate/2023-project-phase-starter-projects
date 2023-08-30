import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class UserProfilePhoto extends StatelessWidget {
  final String photoUrl;

  const UserProfilePhoto({
    Key? key,
    required this.photoUrl,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double containerSize = 84.0.w;
    double borderRadius = 28.0.w;
    double marginSize = 3.0.w;
    double paddingSize = 8.65.w;

    return Container(
      padding: EdgeInsets.all(paddingSize),
      child: Container(
        width: containerSize,
        height: containerSize,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(borderRadius),
          gradient: const LinearGradient(
            colors: [Color(0xFF376AED), Color(0xFF49B0E2), Color(0xFF9CECFB)],
          ),
        ),
        child: Container(
          margin: EdgeInsets.all(marginSize),
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(borderRadius - marginSize),
          ),
          child: Container(
            padding: EdgeInsets.all(paddingSize),
            child: ClipRRect(
              borderRadius: BorderRadius.circular(borderRadius - marginSize),
              child: CachedNetworkImage(
                fit: BoxFit.cover,
                imageUrl: photoUrl,
              ),
            ),
          ),
        ),
      ),
    );
  }
}
