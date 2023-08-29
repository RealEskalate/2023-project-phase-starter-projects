import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import 'on_boarding.dart';

class SplashScreenStatic extends StatelessWidget {
  const SplashScreenStatic({super.key});

  @override
  Widget build(BuildContext context) {
    double screenHeight = MediaQuery.of(context).size.height;
    double screenWidth = MediaQuery.of(context).size.width;

    return Scaffold(
      body: GestureDetector(
        onTap: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const OnBoarding()),
          );
        },
        child: Stack(
          alignment: Alignment.center,
          children: [
            Container(
              width: MediaQuery.of(context).size.width,
              height: MediaQuery.of(context).size.height,
              color: AppColors.grayLight,
            ),
            Positioned(
              top: 0,
              left: 0,
              right: 0,
              child: Image.asset(
                'assets/images/Path_2.png',
                fit: BoxFit.fitWidth,
              ),
            ),
            Positioned(
              bottom: 0,
              left: 0,
              child: Image.asset('assets/images/Path_3.png'),
            ),
            Positioned(
              right: 0,
              left: screenWidth / 4,
              top: screenHeight / 3,
              child: Image.asset(
                'assets/images/Path_1.png',
                fit: BoxFit.cover,
              ),
            ),
            Image.asset('assets/images/A2sv_logo.png'),
          ],
        ),
      ),
    );
  }
}
