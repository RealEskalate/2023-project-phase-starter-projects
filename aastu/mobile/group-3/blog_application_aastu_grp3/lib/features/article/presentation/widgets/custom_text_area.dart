import 'package:flutter/material.dart';

class CustomTextArea extends StatelessWidget {
  const CustomTextArea({required this.placeholder, super.key});
  final String placeholder;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 342,
      decoration: BoxDecoration(
        color: const Color(0xFFF8FAFF),
        borderRadius: BorderRadius.circular(10),
      ),
      child: TextField(
        maxLines: 13,
        decoration: InputDecoration(
          hintText: placeholder,
          hintStyle: const TextStyle(
            fontFamily: 'Poppins',
            fontWeight: FontWeight.w300,
            fontSize: 11,
            color: Color(0XFF979EA5),
          ),
          border: OutlineInputBorder(
              borderSide: const BorderSide(
                color: Color.fromARGB(255, 222, 225, 232),
              ),
              borderRadius: BorderRadius.circular(10)),
          contentPadding: const EdgeInsets.all(20),
        ),
      ),
    );
  }
}
