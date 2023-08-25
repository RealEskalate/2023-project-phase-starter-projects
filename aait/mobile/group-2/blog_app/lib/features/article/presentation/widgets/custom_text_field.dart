import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomTextField extends StatelessWidget {
  final String hintText;

  const CustomTextField({super.key, required this.hintText});

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      style: const TextStyle(
        color: AppColors.darkerBlue,
        fontFamily: 'Poppins',
        fontSize: 18,
      ),
      decoration: InputDecoration(
        constraints: BoxConstraints(
          maxWidth: MediaQuery.of(context).size.width,
        ),
        border: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: AppColors.gray50,
          ),
        ),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: AppColors.gray50,
          ),
        ),
        focusedBorder: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: AppColors.gray50,
          ),
        ),
        hintText: hintText,
        hintStyle: const TextStyle(
          color: AppColors.gray300,
          fontFamily: 'Poppins',
          fontSize: 18,
          fontWeight: FontWeight.w200,
        ),
        isDense: true,
        contentPadding: const EdgeInsets.symmetric(vertical: 10),
        floatingLabelBehavior: FloatingLabelBehavior.never,
      ),
    );
  }
}
