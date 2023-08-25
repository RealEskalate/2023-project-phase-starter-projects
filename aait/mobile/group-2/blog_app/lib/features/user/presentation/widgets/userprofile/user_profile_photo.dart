import 'package:flutter/material.dart';

class UserProfilePhoto extends StatelessWidget {
  final String photoUrl;
  const UserProfilePhoto({
    super.key,
    required this.photoUrl,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(8.65),
      child: Container(
        width: 84.0,
        height: 84.0,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(28.0),
          gradient: const LinearGradient(
            colors: [Color(0xFF376AED), Color(0xFF49B0E2), Color(0xFF9CECFB)],
          ),
        ),
        child: Container(
          margin: const EdgeInsets.all(3.0),
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(22.0),
          ),
          child: Container(
            padding: const EdgeInsets.all(8.65),
            child: ClipRRect(
              borderRadius: BorderRadius.circular(22),
              child: Image.network(
                photoUrl,
                fit: BoxFit.cover,
              ),
            ),
          ),
        ),
      ),
    );
  }
}
