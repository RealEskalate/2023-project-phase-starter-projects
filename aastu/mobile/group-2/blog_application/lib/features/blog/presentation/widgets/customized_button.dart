import 'package:flutter/material.dart';

class CustomizedButton extends StatelessWidget {
  final Icon icon;

  const CustomizedButton({
    super.key,
    required this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return FloatingActionButton(
      onPressed: () {},
      backgroundColor: const Color(0xFF659AFF),
      child: Icon(
        icon.icon,
        size: 30,
        color: Colors.white,
      ),
    );
  }
}
