import 'package:flutter/material.dart';

import 'profile_tab_item.dart';

class ProfileTab extends StatelessWidget {
  const ProfileTab({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 231,
      height: 68,
      decoration: ShapeDecoration(
        shadows: const [
          BoxShadow(
            color: Color(0x0F5182FF),
            blurRadius: 15,
            offset: Offset(0, 10),
            spreadRadius: 0,
          ),

        ],
        color: Color(0xFF386BED),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12),
        ),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          ProfileTabItem(selected: true, top: '52', bottom: 'Post',),
          ProfileTabItem(top: '250', bottom: 'Following'),
          ProfileTabItem(top: '4.5K', bottom: 'Followers'),
        ]
      )
    );
  }
}