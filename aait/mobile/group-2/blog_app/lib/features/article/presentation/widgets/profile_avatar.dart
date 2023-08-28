import 'package:flutter/material.dart';

class ProfileAvatar extends StatelessWidget {
  final String image;
  const ProfileAvatar({required this.image, super.key});

  @override
  Widget build(BuildContext context) {
    return Stack(
      alignment: Alignment.center,
      children: [
        CircleAvatar(
          radius: 20.0,
          backgroundColor: Colors.blue,
          backgroundImage: AssetImage(image),
        ),
        Container(
          width: 38.0,
          height: 38.0,
          decoration: BoxDecoration(
            color: Colors.transparent,
            borderRadius: BorderRadius.circular(100.0),
            border: Border.all(
              color: Colors.white,
              width: 1.5,
            ),
          ),
        ),
      ],
    );
  }
}
