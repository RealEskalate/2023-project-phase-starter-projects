import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomizeTextFieldWidget extends StatelessWidget {
  final String text;
  final IconData icon;
  final TextEditingController controller;
  const CustomizeTextFieldWidget(
      {super.key, required this.text, required this.icon, required this.controller});

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: controller,
      style: TextStyle(
        fontFamily: 'Urbanist',
        fontWeight: FontWeight.w500,
        fontSize: 16.sp,
      ),
      decoration: InputDecoration(
        hintText: "   $text",
        prefixIcon: Icon(icon,
        size: 30.sp,),
      ),
    );
  }
}
