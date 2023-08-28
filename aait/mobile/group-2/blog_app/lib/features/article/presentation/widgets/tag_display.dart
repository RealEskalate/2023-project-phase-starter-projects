import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/article.dart';

class TagDisplay extends StatelessWidget {
  const TagDisplay({
    super.key,
    required this.article,
  });

  final Article article;

  @override
  Widget build(BuildContext context) {
    if (article.tags.isNotEmpty) {
      return Container(
        padding: const EdgeInsets.only(left: 7, right: 7, top: 4, bottom: 4).w,
        decoration: BoxDecoration(
          color: AppColors.gray600,
          borderRadius: BorderRadius.circular(5),
        ),
        child: Text(
          article.tags[0].name,
          style: TextStyle(color: Colors.white, fontSize: 15.h),
        ),
      );
    } else {
      return Container(
        width: 10,
      );
    }
  }
}
