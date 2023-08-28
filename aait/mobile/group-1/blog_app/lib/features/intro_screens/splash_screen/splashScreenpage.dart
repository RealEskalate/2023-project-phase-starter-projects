import 'dart:async';
import 'package:blog_app/features/intro_screens/onboarding_screens/onboarding_screen1.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';


class SplashScreen extends StatefulWidget{

  @override
  _SplashScreenState createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  void initState() {

    super.initState();
    Timer(const Duration(seconds: 3),
            ()=>Navigator.pushReplacement(context,
            MaterialPageRoute(builder:
                (context) =>
                   OnboardingPage()
            )
        )
    );
  }
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Stack(
                children: [
                  Image.asset(
                    "assets/images/a2svImage.png",
                    height: double.infinity,
                    width: double.infinity,
                    fit: BoxFit.cover,
                  ),
                ],
              ),
          ),
    );
  }
}



