import 'package:flutter/material.dart';
import '../../../../core/presentation/theme/app_colors.dart';

class CustomChip extends StatelessWidget {
  final String label;
  final VoidCallback onDelete;

  const CustomChip({super.key, required this.label, required this.onDelete});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.fromLTRB(15, 4, 4, 4),
      decoration: BoxDecoration(
        border: Border.all(
          color: AppColors.blue,
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
              color: AppColors.blue,
              fontFamily: 'Poppins',
              fontSize: 12,
              fontWeight: FontWeight.w500,
            ),
          ),
          const SizedBox(width: 5),
          Container(
            padding: const EdgeInsets.all(6),
            decoration: BoxDecoration(
              color: AppColors.translucentBlue,
              borderRadius: BorderRadius.circular(75),
            ),
            child: GestureDetector(
              onTap: onDelete,
              child: const Icon(
                Icons.close,
                color: AppColors.blue,
                size: 15,
              ),
            ),
          ),
        ],
      ),
    );
  }
}
