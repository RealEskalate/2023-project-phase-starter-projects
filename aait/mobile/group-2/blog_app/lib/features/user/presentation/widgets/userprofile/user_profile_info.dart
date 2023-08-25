import 'package:flutter/material.dart';

class UserProfileInfo extends StatelessWidget {
  final String username, fullName, profession;
  const UserProfileInfo({
    super.key,
    required this.username,
    required this.fullName,
    required this.profession,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(username,
            style: const TextStyle(
              fontSize: 14,
              fontWeight: FontWeight.w900,
              color: Color(0xFF2D4379),
            )),
        const SizedBox(
          height: 2,
        ),
        Text(
          fullName,
          style: const TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.w100,
            fontStyle: FontStyle.italic,
            color: Color(0xFF0D253C),
          ),
        ),
        const SizedBox(
          height: 11,
        ),
        Text(
          profession,
          style: const TextStyle(
            fontSize: 16,
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.w100,
            color: Color(0xFF376AED),
          ),
        ),
      ],
    );
  }
}
