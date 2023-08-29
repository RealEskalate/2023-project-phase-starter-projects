import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomTextField extends StatelessWidget {
  final String hintText;
  final TextEditingController? controller;
  final FocusNode? focusNode;

  const CustomTextField({
    super.key,
    required this.hintText,
    this.controller,
    this.focusNode,
  });

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: controller,
      focusNode: focusNode,
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
            color: AppColors.gray500,
          ),
        ),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: AppColors.gray500,
          ),
        ),
        focusedBorder: const UnderlineInputBorder(
          borderSide: BorderSide(
            color: AppColors.blue,
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
