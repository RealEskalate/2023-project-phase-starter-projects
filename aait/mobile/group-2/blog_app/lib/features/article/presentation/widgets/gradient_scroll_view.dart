import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class GradientScrollView extends StatelessWidget {
  final Widget child;

  const GradientScrollView({super.key, required this.child});

  @override
  Widget build(BuildContext context) {
    return ShaderMask(
      shaderCallback: (Rect bounds) => const LinearGradient(
        begin: Alignment.topCenter,
        end: Alignment.bottomCenter,
        colors: [
          Colors.transparent,
          AppColors.white,
        ],
        stops: [0.85, 1],
      ).createShader(bounds),
      blendMode: BlendMode.dstOut,
      child: SingleChildScrollView(child: child),
    );
  }
}
