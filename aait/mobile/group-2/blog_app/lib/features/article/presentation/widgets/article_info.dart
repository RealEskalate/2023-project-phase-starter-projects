import 'package:blog_app/features/article/presentation/widgets/tag_display.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../domain/entities/article.dart';

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
        Expanded(
          child: Container(
            width: 200,
            child: Text(
              article.title.toUpperCase(),
              style: const TextStyle(
                fontSize: 16.5,
              ),
              softWrap: true,
            ),
          ),
        ),
        SizedBox(height: 30.h),
        TagDisplay(article: article),
        SizedBox(height: 10.h),
        Text(
          'by ${article.author}',
          style: const TextStyle(fontSize: 15.0),
        ),
        Align(
          alignment: Alignment.bottomRight,
          child: Text(
            article.date.toString(),
            style: TextStyle(color: Theme.of(context).colorScheme.onBackground),
          ),
        ),
      ],
    );
  }
}
