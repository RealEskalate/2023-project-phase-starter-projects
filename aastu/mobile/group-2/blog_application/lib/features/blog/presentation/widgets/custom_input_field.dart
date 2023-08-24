import 'package:flutter/material.dart';

import 'customized_button.dart';

class CustomInputField extends StatelessWidget {
  const CustomInputField({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
            width: 396,
            height: 50.43,
            decoration: ShapeDecoration(
              color: Colors.white,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
              shadows: const [
                BoxShadow(
                  color: Color(0x3FB1B1B1),
                  blurRadius: 6,
                  offset: Offset(0, 1),
                  spreadRadius: 0,
                )
              ],
            ),
            child:TextField(
              decoration: InputDecoration(
                border: OutlineInputBorder(
                  borderSide: BorderSide.none,
                  borderRadius: BorderRadius.circular(10),
                ),
                hintText: 'search and article...',
                hintStyle: const TextStyle(
                  color: Color(0xFF9A9494),
                  fontSize: 15,
                  fontWeight: FontWeight.w300,
                ),
                suffixIcon: const CustomizedButton(
                  icon: Icon(Icons.search),
                ),
              ),
            ) ,
          );
  }
}
