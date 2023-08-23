import 'package:flutter/material.dart';

import 'article_info.dart';

class MyPostCard extends StatelessWidget {
  final String title;
  final String subtitle;

  const MyPostCard({
    required this.title,
    required this.subtitle,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 295,
      height: 141,
      decoration: ShapeDecoration(
        color: Colors.white,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16),
        ),
        shadows: const [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 15,
            offset: Offset(0, 10),
            spreadRadius: 0,
          )
        ],
      ),
      child: Row(crossAxisAlignment: CrossAxisAlignment.center, children: [
        const Image(
          image: AssetImage('assets/images/article.jpg'),
        ),
        ArticleInfo(
          title: title,
          subtitle: subtitle,
        ),
      ]),
    );
  }
}
