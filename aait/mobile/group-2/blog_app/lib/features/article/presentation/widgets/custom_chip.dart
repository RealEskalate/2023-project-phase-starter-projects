import 'package:flutter/material.dart';

class CustomChip extends StatelessWidget {
  final String label;

  const CustomChip({super.key, required this.label});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.fromLTRB(15, 4, 4, 4),
      decoration: BoxDecoration(
        border: Border.all(
          color: const Color(0xFF376AED),
          width: 2,
        ),
        borderRadius: BorderRadius.circular(75),
      ),
      child: Row(
        mainAxisSize: MainAxisSize.min,
        children: [
          Text(
            label,
            style: const TextStyle(
              color: Color(0xFF376AED),
              fontFamily: 'Poppins',
              fontSize: 12,
              fontWeight: FontWeight.w500,
            ),
          ),
          const SizedBox(width: 5),
          Container(
            padding: const EdgeInsets.all(6),
            decoration: BoxDecoration(
              color: const Color(0x26376AED),
              borderRadius: BorderRadius.circular(75),
            ),
            child: GestureDetector(
              onTap: () {},
              child: const Icon(
                Icons.close,
                color: Color(0xFF376AED),
                size: 15,
              ),
            ),
          ),
        ],
      ),
    );
  }
}
