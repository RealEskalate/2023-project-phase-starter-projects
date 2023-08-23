
import 'package:flutter/material.dart';

class FeedContent extends StatelessWidget {
  final Widget innerContent;

  const FeedContent({super.key, required this.innerContent});
  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      margin: EdgeInsets.zero,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.only(
              topLeft: Radius.circular(20), topRight: Radius.circular(20))),
      child: Material(
        borderRadius: BorderRadius.only(
            topLeft: Radius.circular(20), topRight: Radius.circular(20)),
        elevation: 10,
        child: innerContent,
      ),
    );
  }
}