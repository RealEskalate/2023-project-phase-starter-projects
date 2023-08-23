import 'package:flutter/material.dart';

class CustomTextField extends StatelessWidget {
  const CustomTextField({required this.placeholder, super.key});
  final String placeholder;

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: InputDecoration(
        hintText: placeholder,
        hintStyle: const TextStyle(
          fontFamily: 'Poppins',
          fontWeight: FontWeight.w300,
          fontSize: 19,
          color: Color(0XFF979EA5),
        ),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(color: Color(0xFF7B8BB2)),
        ),
      ),
    );
  }
}
