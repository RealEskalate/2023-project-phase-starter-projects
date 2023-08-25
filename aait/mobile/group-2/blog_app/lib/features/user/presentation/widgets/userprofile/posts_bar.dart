import 'package:flutter/material.dart';

class ArticleTitleBar extends StatelessWidget {
  final String title;
  const ArticleTitleBar({
    super.key,
    required this.title,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text(
          title,
          style: TextStyle(
            fontSize: 20,
            fontWeight: FontWeight.w500,
            color: Color(0xFF0D253C),
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Icon(
              Icons.grid_view,
              color: Color(0xFF376AED),
            ),
            SizedBox(width: 12),
            Icon(
              Icons.list,
              color: Color(0xFF7B8BB2),
            ),
          ],
        )
      ],
    );
  }
}
