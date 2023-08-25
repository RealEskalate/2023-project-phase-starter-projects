import 'package:flutter/material.dart';

class ProfileBar extends StatelessWidget {
  const ProfileBar({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.fromLTRB(40, 24, 40, 0),
      child: const Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            "Profile",
            style: TextStyle(
              fontSize: 24,
              fontWeight: FontWeight.w500,
              color: Color(0xFF0D253C),
            ),
          ),
          Icon(
            Icons.more_horiz,
            color: Color(0xFF0D253C),
          ),
        ],
      ),
    );
  }
}
