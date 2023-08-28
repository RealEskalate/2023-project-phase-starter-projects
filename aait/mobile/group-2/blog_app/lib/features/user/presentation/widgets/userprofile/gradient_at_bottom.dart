import 'package:flutter/material.dart';

class GradientAtBottom extends StatelessWidget {
  const GradientAtBottom({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Positioned(
        bottom: 0,
        left: 0,
        right: 0,
        child: Container(
          height: 120,
          decoration: BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topCenter,
              end: Alignment.bottomCenter,
              colors: [
                Colors.white.withOpacity(0),
                Colors.white.withOpacity(1),
              ],
            ),
          ),
        ));
  }
}
