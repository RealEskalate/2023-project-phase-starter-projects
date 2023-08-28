import 'dart:ui';
import 'package:flutter/material.dart';

class CustomShaderMaskWidget extends StatelessWidget {
  final Widget child;
  final Color maskColor;
  final double blurSigma;
  final double alignmentEnd;

  const CustomShaderMaskWidget({
    super.key,
    required this.child,
    this.maskColor = Colors.white,
    this.blurSigma = 2.0,
    this.alignmentEnd = 0.7,
  });

  @override
  Widget build(BuildContext context) {
    return ShaderMask( 
      shaderCallback: (Rect bounds) {
        return LinearGradient(
          begin: Alignment.bottomCenter,
          end: Alignment(0, alignmentEnd),
          colors: [
            Colors.white.withOpacity(0.2),
            maskColor.withOpacity(1.0),
          ],
          stops: const [0.0, 1.0],
        ).createShader(bounds);
      },
      child: BackdropFilter(
        filter: ImageFilter.blur(sigmaX: blurSigma, sigmaY: blurSigma),
        child: child,
      ),
    );
  }
}
