import 'package:flutter/material.dart';

class UserBio extends StatelessWidget {
  final userInfo;
  const UserBio({
    super.key,
    required this.userInfo,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          alignment: Alignment.centerLeft,
          padding: const EdgeInsets.fromLTRB(0, 24.0, 0, 0),
          child: const Text(
            'About me',
            textAlign: TextAlign.start,
            style: TextStyle(
              fontSize: 16,
              fontStyle: FontStyle.italic,
              fontWeight: FontWeight.w100,
              color: Color(0xFF0D253C),
            ),
          ),
        ),
        const SizedBox(
          height: 11,
        ),
        Text(
          userInfo,
          textAlign: TextAlign.start,
          style: const TextStyle(
            fontSize: 14,
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.w100,
            color: Color(0xFF2D4379),
          ),
        ),
        const SizedBox(
          height: 20.0,
        ),
      ],
    );
  }
}
