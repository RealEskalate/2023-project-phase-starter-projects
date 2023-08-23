
import 'package:flutter/material.dart';

class TitleBar extends StatelessWidget {
  TitleBar({
    super.key,
  });

  final Color blackColor = Color(0xFF0D253C);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Padding(
          padding: EdgeInsets.only(left: 40, top: 68),
          child: Text(
            "Profile",
            style: TextStyle(fontSize: 24, fontWeight: FontWeight.w500),
          ),
        ),
        Padding(
          padding: EdgeInsets.only(right: 40, top: 68),
          child: IconButton(
            onPressed: null,
            icon: Icon(
              Icons.more_horiz,
              color: blackColor,
            ),
          ),
        ),
      ],
    );
  }
}