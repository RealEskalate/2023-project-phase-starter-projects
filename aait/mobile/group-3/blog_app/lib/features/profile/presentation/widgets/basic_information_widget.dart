
import 'package:flutter/material.dart';

class BasicInformationWidget extends StatelessWidget {
  final String username;
  final String fullName;
  final String occupation;

  const BasicInformationWidget(
      {super.key,
      required this.username,
      required this.fullName,
      required this.occupation});
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(
          this.username,
          style: TextStyle(
              fontWeight: FontWeight.w900,
              fontSize: 14,
              color: Color(0xFF2D4379)),
        ),
        Text(
          this.fullName,
          style: TextStyle(fontWeight: FontWeight.w100, fontSize: 18),
        ),
        SizedBox(
          height: 11,
        ),
        Text(
          this.occupation,
          style: TextStyle(
              fontWeight: FontWeight.w100,
              fontSize: 16,
              color: Color(0xFF376AED)),
        )
      ],
    );
  }
}