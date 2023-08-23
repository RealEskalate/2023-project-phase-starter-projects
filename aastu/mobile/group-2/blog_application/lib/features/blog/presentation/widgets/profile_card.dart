import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class ProfileCard extends StatelessWidget {
  const ProfileCard({super.key});
  @override
  Widget build(BuildContext context) {
    return Container(
        width: 295,
        height: 284,
        decoration: ShapeDecoration(
          color: Colors.white,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(16),
          ),
          shadows: const [
            BoxShadow(
              color: Color(0x0F5182FF),
              blurRadius: 15,
              offset: Offset(0, 10),
              spreadRadius: 0,
            )
          ],
        ),
        child: Padding(
          padding: const EdgeInsets.all(32.0),
          child:
              Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
            Row(
              children: [
                Container(
                    width: 84,
                    height: 84,
                    decoration: ShapeDecoration(
                      shape: RoundedRectangleBorder(
                        side: BorderSide(width: 2, color: Color(0xFF376AED)),
                        borderRadius: BorderRadius.circular(28),
                      ),
                    ),
                    child: Container(
                      width: 66.71,
                      height: 66.71,
                      decoration: ShapeDecoration(
                        image: const DecorationImage(
                          image:
                              AssetImage('assets/images/photocv.jpg'),
                          fit: BoxFit.fill,
                        ),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(22),
                        ),
                      ),
                    )),
                const SizedBox(width: 24),
                 Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
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
                    Text(
                      'Jovi Daniel',
                      style: TextStyle(
                        color: Color(0xFF0D253C),
                        fontSize: 18,
                        fontStyle: FontStyle.italic,
                        fontFamily: GoogleFonts.urbanist().fontFamily,
                        fontWeight: FontWeight.w100,
                      ),
                    ),
                    Text(
                      'UX Designer',
                      style: TextStyle(
                        color: Color(0xFF376AED),
                        fontSize: 16,
                        fontStyle: FontStyle.italic,
                        fontFamily: GoogleFonts.urbanist().fontFamily,
                        fontWeight: FontWeight.w100,
                        height: 1.25,
                      ),
                    )
                  ],
                )
              ],
            ),
            SizedBox(height: 24),
            Text(
              'About me',
              style: TextStyle(
                color: Color(0xFF0D253C),
                fontSize: 16,
                fontStyle: FontStyle.italic,
                fontFamily: GoogleFonts.urbanist().fontFamily,
                fontWeight: FontWeight.w100,
              ),
            ),
            SizedBox(height: 11),
            Text(
              'Madison Blackstone is a director of user experience design, with experience managing global teams.',
              style: TextStyle(
                color: Color(0xFF2D4379),
                fontSize: 14,
                fontStyle: FontStyle.italic,
                fontFamily: GoogleFonts.urbanist().fontFamily,
                fontWeight: FontWeight.w100,
                height: 1.43,
              ),
            ),
          ]),
        ));
  }
}
