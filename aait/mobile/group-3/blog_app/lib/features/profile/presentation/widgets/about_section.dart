
import 'package:flutter/material.dart';

class AboutSection extends StatelessWidget {
  final String description;

  const AboutSection({super.key, required this.description});
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(bottom: 54),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            "About me",
            style: TextStyle(fontWeight: FontWeight.w100, fontSize: 16),
          ),
          SizedBox(
            height: 11,
          ),
          Text(
            description,
            style: TextStyle(fontSize: 14, fontWeight: FontWeight.w100),
          ),
          SizedBox(
            height: 54,
          )
        ],
      ),
    );
  }
}