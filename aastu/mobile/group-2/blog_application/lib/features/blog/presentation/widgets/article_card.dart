import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class ArticleCard extends StatelessWidget {
  final String title;
  final String author;
  final String date;
  final String tag;

  const ArticleCard({
    required this.title,
    required this.author,
    required this.date,
    required this.tag,
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 388,
      height: 240,
      decoration: ShapeDecoration(
        color: Colors.white,
        shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
        ),
        shadows: const [
          BoxShadow(
          color: Color(0x07000000),
          blurRadius: 8,
          offset: Offset(-4, -4),
          spreadRadius: 0,
          )
        ],
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.end,
        children: [
          Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Flexible(
                child: Stack(
                  children: [
                    const Image(
                      image: AssetImage('assets/images/article.jpg'),
                    ),
                    Positioned(
                      left: 20,
                      top: 20,
                      child: Container(
                        width: 76,
                        height: 26,
                        decoration: ShapeDecoration(
                          color: Colors.white,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10),
                          ),
                        ),
                        child: const Center(
                          child: Text(
                            '5 min read',
                            style: TextStyle(
                              color: Color(0xFF414141),
                              fontSize: 10,
                              fontWeight: FontWeight.w500,
                              letterSpacing: 0.20,
                            ),
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                   SizedBox(
                    width: 150,
                    child: Text(
                      title,
                      style: TextStyle(
                        color: Color(0xFF4D4A49),
                        fontSize: 15,
                        fontFamily: GoogleFonts.urbanist().fontFamily,
                        fontWeight: FontWeight.w600,
                        letterSpacing: 0.36,
                      ),
                    ),
                  ),
                  const SizedBox(height: 10),
                  Container(
                    width: 71,
                    height: 21,
                    decoration: ShapeDecoration(
                      color: const Color(0xFF5D5E6F),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(3),
                      ),
                    ),
                    child:  Center(
                      child: Text(
                        tag,
                        style: const TextStyle(
                          fontSize: 10,
                          fontWeight: FontWeight.w600,
                          color: Colors.white,
                        ),
                      ),
                    ),
                  ),
                  const SizedBox(height: 10),
                   Text(
                    "by $author",
                    style: const TextStyle(
                      color: Color(0xFF414141),
                      fontSize: 14,
                      fontWeight: FontWeight.w400,
                      letterSpacing: 0.28,
                    ),
                  ),
                ],
              ),
            ],
          ),
          Text(
            date,
            style: const TextStyle(
              color: Color(0xFF7D7D7D),
              fontSize: 12,
              fontWeight: FontWeight.w300,
              letterSpacing: 0.24,
            ),
          )
        ],
      ),
    );
  }
}
