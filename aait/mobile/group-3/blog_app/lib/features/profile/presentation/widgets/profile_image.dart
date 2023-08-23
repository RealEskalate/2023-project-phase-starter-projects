
import 'package:flutter/material.dart';

class ProfileImage extends StatelessWidget {
  final String imageName;
  final kInnerDecoration = BoxDecoration(
      color: Colors.white,
      border: Border.all(color: Colors.white),
      borderRadius: BorderRadius.circular(24));
  final kOuterDecoration = BoxDecoration(
      gradient: LinearGradient(
          colors: [Color(0xFF376AED), Color(0xFF49B0E2), Color(0xFF9CECFB)]),
      borderRadius: BorderRadius.circular(24));

  ProfileImage({super.key, required this.imageName});
  @override
  Widget build(BuildContext context) {
    return Container(
      width: 84,
      height: 84,
      child: Padding(
        padding: EdgeInsets.symmetric(horizontal: 2, vertical: 2),
        child: Container(
          alignment: Alignment.center,
          child: ClipRRect(
            borderRadius: BorderRadius.circular(24),
            child: Image.network(
              imageName,
              width: 66.71,
              height: 66.71,
              fit: BoxFit.cover,
            ),
          ),
          decoration: kInnerDecoration,
        ),
      ),
      decoration: kOuterDecoration,
    );
  }
}