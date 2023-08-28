import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class AboutSection extends StatelessWidget {
  final String description;

  const AboutSection({super.key, required this.description});
  @override
  Widget build(BuildContext context) {
    return Container(
      height: 172.h,
      child: Column(
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "About me",
                style: TextStyle(fontWeight: FontWeight.w100, fontSize: 16),
              ),
              SizedBox(
                height: 11.h,
              ),
              Text(
                description,
                style: TextStyle(fontSize: 14, fontWeight: FontWeight.w100),
              ),
              SizedBox(
                height: 54.h,
              )
            ],
          ),
        ],
      ),
    );
  }
}
