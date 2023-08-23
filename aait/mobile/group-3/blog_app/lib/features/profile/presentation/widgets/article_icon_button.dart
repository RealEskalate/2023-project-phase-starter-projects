
import 'package:flutter/material.dart';

class ArticleIconButton extends StatelessWidget {
  final textValue;
  final IconData icon;
  final Color darkBlue = Color(0xFF2D4379);
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
          width: 6,
        ),
        Text(
          textValue,
          style: TextStyle(
              fontWeight: FontWeight.w500, fontSize: 12, color: darkBlue),
        )
      ],
    );
  }
}