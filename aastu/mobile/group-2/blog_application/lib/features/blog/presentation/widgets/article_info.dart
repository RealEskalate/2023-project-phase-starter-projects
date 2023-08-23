import 'package:flutter/material.dart';

class ArticleInfo extends StatelessWidget {
  final String title;
  final String subtitle;
  const ArticleInfo({required this.title, required this.subtitle, super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        Text(
          title,
          style: const TextStyle(
            color: Color(0xFF376AED),
            fontSize: 14,
            fontStyle: FontStyle.italic,
            fontFamily: 'Urbanist',
            fontWeight: FontWeight.w100,
            height: 1.43,
          ),
        ),
        const SizedBox(
          width: 163,
          child: Text(
            'Why Big Data Needs Thick Data?',
            style: TextStyle(
              color: Color(0xFF0D253C),
              fontSize: 14,
              fontFamily: 'Urbanist',
              fontWeight: FontWeight.w500,
              height: 1.43,
            ),
          ),
        ),
        const SizedBox(
          height: 10,
        ),
        const Row(
          children: [
            Icon(
              Icons.thumb_up_alt_outlined,
              size: 15,
            ),
            Text(
              '2.1k',
              style: TextStyle(
                color: Color(0xFF2D4379),
                fontSize: 12,
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w500,
                height: 1.33,
              ),
            ),
            SizedBox(
              width: 20,
            ),
            Icon(
              Icons.access_time,
              size: 15,
            ),
            Text(
              '1hr ago',
              style: TextStyle(
                color: Color(0xFF2D4379),
                fontSize: 12,
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w500,
                height: 1.33,
              ),
            ),
            SizedBox(
              width: 20,
            ),
            Icon(
              Icons.bookmark,
              color: Color(0xFF2151CD),
              size: 20,
            ),
          ],
        )
      ],
    );
  }
}
