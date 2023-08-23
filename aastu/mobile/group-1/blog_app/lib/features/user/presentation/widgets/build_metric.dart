import 'package:flutter/material.dart';

Widget buildCustomMetricRow(String title, String value,
    {bool isFirst = false}) {
  final color = isFirst
      ? const Color.fromARGB(255, 8, 85, 148)
      : const Color.fromARGB(255, 33, 150, 243); // Adjust the colors as needed

  return Container(
    width: 80,
    height: 300,
    decoration: BoxDecoration(
      color: color, // Set the background color here
      borderRadius: isFirst ? BorderRadius.circular(16) : null,
    ),
    child: Center(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Center(
            child: Padding(
              padding:
                  EdgeInsets.only(top: isFirst ? 16 : 10), // Adjust the padding
              child: Text(
                title,
                style: const TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.w400,
                  fontFamily: 'Urbanist',
                  //  fontSize: 20,
                  // height: 22,
                ),
              ),
            ),
          ),
          Center(
            child: Text(
              value,
              style: const TextStyle(
                color: Colors.white,
                fontWeight: FontWeight.w400,
                fontFamily: 'Urbanist',
                // fontSize: 18,
                // height: 18,
              ),
            ),
          ),
        ],
      ),
    ),
  );
}
