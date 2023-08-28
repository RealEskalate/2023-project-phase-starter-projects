import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../domain/entities/article.dart';
import 'article_info.dart';
import 'article_photo.dart';

class ArticleCard extends StatelessWidget {
  final Article article;

  const ArticleCard({required this.article, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 240.h,
      width: 388.w,
      padding: const EdgeInsets.all(10.0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20.0),
        color: Colors.white,
      ),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          ArticlePhoto(article: article),
          const SizedBox(width: 10),
          ArticleInfo(article: article),
        ],
      ),
    );
  }
}
