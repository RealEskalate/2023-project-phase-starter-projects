import 'package:flutter/material.dart';

class ShowPostsOrBookmarksButton extends StatelessWidget {
  final Color col;
  final String typeOfChoice;
  final int count;
  const ShowPostsOrBookmarksButton({
    super.key,
    required this.col,
    required this.typeOfChoice,
    required this.count,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.only(top: 12),
      width: 130.5,
      height: 68,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(12.0),
        color: col,
      ),
      child: Column(
        children: [
          Text(
            "$count",
            style: const TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.w400,
              color: Colors.white,
            ),
          ),
          Text(
            typeOfChoice,
            style: const TextStyle(
              fontSize: 12,
              fontWeight: FontWeight.w400,
              color: Colors.white,
            ),
          ),
        ],
      ),
    );
  }
}
