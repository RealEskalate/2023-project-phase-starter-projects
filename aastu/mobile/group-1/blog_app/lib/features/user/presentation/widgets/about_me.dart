import 'package:flutter/material.dart';
import '../widgets/build_metric.dart';

class Aboutme extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: 295,
      height: 318,
      decoration: ShapeDecoration(
        color: const Color.fromARGB(255, 255, 255, 255),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16),
        ),
        // shadows: [
        //   BoxShadow(
        //     color: Color(0x0F5182FF),
        //     blurRadius: 15,
        //     offset: Offset(0, 10),
        //     spreadRadius: 0,
        //   ),
        // ],
      ),
      child: Column(
        children: [
          Column(
            children: [
              Container(
                color: const Color.fromARGB(255, 255, 255, 255),
                width: double.infinity,
                height: 120,
                padding: const EdgeInsets.all(16),
                child: Row(
                  children: [
                    Container(
                      width: 84,
                      height: 84,
                      decoration: ShapeDecoration(
                        shape: RoundedRectangleBorder(
                          side: const BorderSide(
                              width: 1, color: Color(0xFF376AED)),
                          borderRadius: BorderRadius.circular(35),
                        ),
                      ),
                      child: Padding(
                        padding: const EdgeInsets.all(10.0),
                        child: Container(
                          width: 67,
                          height: 67,
                          decoration: ShapeDecoration(
                            shape: RoundedRectangleBorder(
                              side: const BorderSide(
                                  width: 1, color: Color(0xFF376AED)),
                              borderRadius: BorderRadius.circular(22),
                            ),
                            image: const DecorationImage(
                              image: AssetImage("assets/images/profile.png"),
                              fit: BoxFit.fill,
                            ),
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(width: 16),
                    const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Text(
                          '@joviedan',
                          style: TextStyle(
                            color: Color(0xFF2D4379),
                            fontSize: 14,
                            fontFamily: 'Poppins',
                            fontWeight: FontWeight.w900,
                            letterSpacing: -0.24,
                          ),
                        ),
                        SizedBox(height: 6),
                        Text(
                          'Jovi Daniel',
                          style: TextStyle(
                            color: Color(0xFF0D253C),
                            fontSize: 18,
                            fontStyle: FontStyle.italic,
                            fontFamily: 'Urbanist',
                            fontWeight: FontWeight.w100,
                          ),
                        ),
                        SizedBox(height: 6),
                        Text(
                          'UX Designer',
                          style: TextStyle(
                            color: Color(0xFF376AED),
                            fontSize: 16,
                            fontStyle: FontStyle.italic,
                            fontFamily: 'Urbanist',
                            fontWeight: FontWeight.w100,
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
              Container(
                child: const Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Padding(
                      padding:
                          EdgeInsets.symmetric(vertical: 8, horizontal: 16),
                      child: Text(
                        'About me',
                        style: TextStyle(
                          color: Color(0xFF0D253C),
                          fontSize: 16,
                          fontStyle: FontStyle.italic,
                          fontFamily: 'Urbanist',
                          fontWeight: FontWeight.w100,
                        ),
                      ),
                    ),
                    Padding(
                      padding:
                          EdgeInsets.symmetric(vertical: 8, horizontal: 16),
                      child: Text(
                        'Madison Blackstone is a director of user experience design, with experience managing global teams.',
                        style: TextStyle(
                          color: Color(0xFF2D4379),
                          fontSize: 14,
                          fontStyle: FontStyle.italic,
                          fontFamily: 'Urbanist',
                          fontWeight: FontWeight.w100,
                          height: 1.43,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),

          Expanded(
            child: Stack(children: [
              const SizedBox(height: 20),
              Align(
                alignment: Alignment.bottomCenter,
                child: FractionallySizedBox(
                  heightFactor: 0.8,
                  child: Padding(
                    padding:
                        const EdgeInsets.symmetric(vertical: 2, horizontal: 16),
                    child: Container(
                      height: 100,
                      decoration: ShapeDecoration(
                        color: const Color.fromARGB(255, 33, 150, 243),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(20),
                        ),
                      ),
                      child: Center(
                        child: Row(
                          children: [
                            buildCustomMetricRow('250', 'Following',
                                isFirst: true),
                            buildCustomMetricRow('4.5K', ' Followers'),
                            buildCustomMetricRow('52', 'Post'),
                          ],
                        ),
                      ),
                    ),
                  ),
                ),
              ),
            ]),
          ),

          // SizedBox(height: 20),
        ],
      ),
    );
  }
}
