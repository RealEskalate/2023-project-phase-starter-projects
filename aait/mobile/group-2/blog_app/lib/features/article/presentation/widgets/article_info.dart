import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/presentation/util/date_to_string_convertor.dart';
import '../../domain/entities/article.dart';
import 'tag_display.dart';

class ArticleInfo extends StatelessWidget {
  const ArticleInfo({
    Key? key,
    required this.article,
  }) : super(key: key);

  final Article article;

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        SizedBox(
          width: 160.w,
          child: Text(
            article.title.toUpperCase(),
            style: const TextStyle(
              fontFamily: 'Poppins',
              fontSize: 20,
              color: AppColors.gray700,
            ),
            softWrap: true,
            overflow: TextOverflow.ellipsis, // Add this line
            maxLines: 2,
          ),
        ),
        SizedBox(height: 10.h),
        TagDisplay(article: article),
        SizedBox(height: 10.h),
        SizedBox(
          width: 160.w,
          child: Text(
            'by ${article.author.fullName}',
            style: const TextStyle(color: AppColors.grayDark, fontSize: 18.0),
            softWrap: true,
            overflow: TextOverflow.ellipsis, // Add this line
            maxLines: 1,
          ),
        ),
        SizedBox(
          height: 50.h,
        ),
        Expanded(
          child: SizedBox(
            width: 160,
            child: Row(children: [
              const Expanded(child: SizedBox()),
              SizedBox(
                width: 100,
                child: Text(
                  dateTimeToString(article.date),
                  style: const TextStyle(color: AppColors.gray300),
                ),
              ),
            ]),
          ),
        )
      ],
    );
  }
}
