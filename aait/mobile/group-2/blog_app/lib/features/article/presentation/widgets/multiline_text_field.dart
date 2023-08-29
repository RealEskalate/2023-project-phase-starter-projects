import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class MultilineTextInput extends StatelessWidget {
  final String hintText;
  final TextEditingController? controller;

  const MultilineTextInput(
      {super.key, required this.hintText, this.controller});

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      maxLines: 11,
      minLines: 5,
      controller: controller,
      style: const TextStyle(
        color: AppColors.darkerBlue,
        fontFamily: 'Poppins',
        fontSize: 18,
      ),
      decoration: InputDecoration(
        border: const OutlineInputBorder(
          borderRadius: BorderRadius.all(Radius.circular(10)),
          borderSide: BorderSide(
            color: AppColors.gray200,
          ),
        ),
        enabledBorder: const OutlineInputBorder(
          borderRadius: BorderRadius.all(Radius.circular(10)),
          borderSide: BorderSide(
            color: AppColors.gray200,
          ),
        ),
        hintText: hintText,
        hintStyle: const TextStyle(
          color: AppColors.gray300,
          fontFamily: 'Poppins',
          fontSize: 13,
          fontWeight: FontWeight.w300,
        ),
        contentPadding: EdgeInsets.all(20),
      ),
    );
  }
}
