import 'package:flutter/material.dart';
import 'package:flutter/material.dart';

class Aboutme extends StatefulWidget {
  final Function(String) onActivitySelected;

  const Aboutme({required this.onActivitySelected});

  @override
  State<Aboutme> createState() => _AboutmeState();
}

class _AboutmeState extends State<Aboutme> {
  int selectedIndex = 1; // Initialize selectedIndex here

  Widget buildCustomMetricRow(String value, String title, int index) {
    final color = index == selectedIndex
        ? const Color.fromARGB(255, 8, 85, 148)
        : const Color.fromARGB(255, 33, 150, 243);

    return GestureDetector(
      onTap: () {
        setState(() {
          selectedIndex = index; // Update selected index for each row
        });
        widget.onActivitySelected(title);
      },
      child: Container(
        width: 80,
        height: 80,
        decoration: BoxDecoration(
          color: color,
          borderRadius: BorderRadius.circular(16),
        ),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Text(
                title,
                style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.w400,
                  fontFamily: 'Urbanist',
                ),
              ),
              SizedBox(height: 8),
              Text(
                value,
                style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.w400,
                  fontFamily: 'Urbanist',
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    Widget buildCustomMetricRow(String value, String title, int isSelected) {
      return GestureDetector(
        onTap: () {
          setState(() {
            selectedIndex = isSelected; // Update selected index for each row
          });
          final color = isSelected == selectedIndex
              ? const Color.fromARGB(255, 8, 85, 148)
              : const Color.fromARGB(255, 33, 150, 243);
          widget.onActivitySelected(title);
        },
        child: Container(
          width: 80,
          height: 80, // Adjust the height as needed
          decoration: BoxDecoration(
            color: isSelected == selectedIndex
                ? const Color.fromARGB(255, 8, 85, 148)
                : const Color.fromARGB(255, 33, 150, 243),
            borderRadius:
                isSelected == selectedIndex ? BorderRadius.circular(16) : null,
          ),
          child: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Text(
                  title,
                  style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w400,
                    fontFamily: 'Urbanist',
                  ),
                ),
                SizedBox(height: 8),
                Text(
                  value,
                  style: TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.w400,
                    fontFamily: 'Urbanist',
                  ),
                ),
              ],
            ),
          ),
        ),
      );
    }

    return Container(
      width: 295,
      height: 318,
      decoration: ShapeDecoration(
        color: Color.fromARGB(255, 255, 255, 255),
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
      child: Stack(alignment: Alignment.bottomCenter, children: [
        Column(
          children: [
            Column(
              children: [
                Container(
                  color: Color.fromARGB(255, 255, 255, 255),
                  width: double.infinity,
                  height: 120,
                  padding: EdgeInsets.all(16),
                  child: Row(
                    children: [
                      Container(
                        width: 84,
                        height: 84,
                        decoration: ShapeDecoration(
                          shape: RoundedRectangleBorder(
                            side:
                                BorderSide(width: 1, color: Color(0xFF376AED)),
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
                                side: BorderSide(
                                    width: 1, color: Color(0xFF376AED)),
                                borderRadius: BorderRadius.circular(22),
                              ),
                              image: DecorationImage(
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
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Padding(
                        padding: const EdgeInsets.symmetric(
                            vertical: 8, horizontal: 16),
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
                        padding: const EdgeInsets.symmetric(
                            vertical: 8, horizontal: 16),
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
            Container(
              // width: 230,
              decoration: BoxDecoration(
                color: const Color.fromARGB(255, 33, 150, 243),
                borderRadius: BorderRadius.circular(16),
              ),
              child: Expanded(
                child: Row(
                  children: [
                    Expanded(
                      child: buildCustomMetricRow(
                        '4.5K',
                        "Posts",
                        1,
                      ),
                    ),
                    Expanded(
                      child: buildCustomMetricRow(
                        '4.5K',
                        "Following",
                        2,
                      ),
                    ),
                    Expanded(
                      child: buildCustomMetricRow(
                        '4.5K',
                        "Follower",
                        3,
                      ),
                    ),
                  ],
                ),
              ),
            ),

            // Expanded(
            //   child: Stack(
            //     children: [
            //       const SizedBox(height: 20),
            //       Center(
            //         child: Align(
            //           alignment: Alignment.bottomCenter,
            //           child: FractionallySizedBox(
            //             heightFactor: 0.8,
            //             child: Padding(
            //               padding: const EdgeInsets.symmetric(
            //                   vertical: 2, horizontal: 16),
            //               child: Container(
            //                 height: 120,
            //                 decoration: ShapeDecoration(
            //                   color: const Color.fromARGB(255, 33, 150, 243),
            //                   shape: RoundedRectangleBorder(
            //                     borderRadius: BorderRadius.circular(20),
            //                   ),
            //                 ),
            //               ),
            //             ),
            //           ),
            //         ),
            //       ),
            //     ],
            //   ),
            // ),
            // SizedBox(height: 20),
          ],
        ),
      ]),
    );
  }
}
