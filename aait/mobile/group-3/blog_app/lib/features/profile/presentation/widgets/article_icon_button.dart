import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ArticleIconButton extends StatelessWidget {
  final textValue;
  final IconData icon;
  ArticleIconButton({
    super.key,
    required this.textValue,
    required this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Icon(
          icon,
          size: 16,
          color: darkBlue,
        ),
        SizedBox(
          width: 6.w,
        ),
        Text(
          textValue,
          style: TextStyle(
              fontWeight: FontWeight.w500, fontSize: 12, color: darkBlueText),
        )
      ],
    );
  }
}
