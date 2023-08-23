
import 'package:flutter/material.dart';

class ButtonContainer extends StatelessWidget {
  final Color? color;
  final int numberValue;
  final String category;

  ButtonContainer(
      {super.key,
      this.color,
      required this.numberValue,
      required this.category});
  final whiteColor = Color(0xFFFFFFff);
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
        print("I am being pressed");
      },
      child: Container(
        alignment: Alignment.center,
        width: 76.7,
        height: 68,
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            color: color ?? Color(0xFF2151CD)),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              numberValue.toString(),
              textAlign: TextAlign.center,
              style: TextStyle(
                  color: whiteColor, fontSize: 20, fontWeight: FontWeight.w400),
            ),
            SizedBox(
              height: 4,
            ),
            Text(
              category,
              textAlign: TextAlign.center,
              style: TextStyle(
                  color: whiteColor, fontSize: 12, fontWeight: FontWeight.w100),
            )
          ],
        ),
      ),
    );
  }
}