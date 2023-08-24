import 'package:flutter/material.dart';

class MiniBlogInfo extends StatelessWidget {
  const MiniBlogInfo({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        ClipRRect(
          borderRadius: BorderRadius.circular(10), // Image border
          child: SizedBox.fromSize(
            size: Size.fromRadius(20), // Image radius
            child: Image.network(
                'https://images.pexels.com/photos/4307869/pexels-photo-4307869.jpeg',
                fit: BoxFit.cover),
          ),
        ),
        Container(
          padding: EdgeInsets.only(left: 10),
          child: const Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "Richard Gervain",
                style: TextStyle(
                    fontSize: 12,
                    fontWeight: FontWeight.w600,
                    color: Color(0xff2D4379)),
              ),
              Text(
                "2m ago",
                style: TextStyle(
                  fontSize: 12,
                  fontWeight: FontWeight.w600,
                  color: Color(0xff7B8BB2),
                ),
              )
            ],
          ),
        ),
      ],
    );
  }
}
