import 'package:blog_app/core/util/app_colors.dart';
import 'package:flutter/material.dart';

class ThemeUtils {
  static ThemeData appTheme = ThemeData(
    useMaterial3: true,
    primaryColor: AppColors.primaryColor,
    cardColor: AppColors.whiteColor,
    disabledColor: AppColors.disabledButtonColor,
    hintColor: AppColors.textExtraLight,
    colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
    fontFamily: 'Poppins', // Default font family
    textTheme: const TextTheme(
      labelSmall: TextStyle(
        fontFamily: 'Poppins-Light',
        color: AppColors.textLightGray,
      ),
      labelLarge: TextStyle(
        fontFamily: 'Poppins-Medium',
        color: AppColors.primaryTextGray,
      ),
      displayLarge: TextStyle(
        fontFamily: 'Poppins-SemiBold',
        color: AppColors.whiteColor,
        fontSize: 2,
      ),
      displayMedium: TextStyle(
        fontFamily: 'Poppins-Regular',
        color: AppColors.primaryTextGray,
        fontSize: 15,
      ),
      headlineLarge: TextStyle(
        fontFamily: 'Poppins-SemiBold',
        fontSize: 27,
        fontWeight: FontWeight.w600,
        height: 2,
        color: AppColors.textDark,
      ),
      titleLarge: TextStyle(
        fontFamily: 'Urbanist-Regular',
        fontSize: 17,
        fontWeight: FontWeight.w400,

        height: 1.3,
      ),
    ),
    floatingActionButtonTheme: const FloatingActionButtonThemeData(
      backgroundColor: AppColors.primaryButtonColor,
      foregroundColor: AppColors.whiteColor,
    ),
    elevatedButtonTheme: const ElevatedButtonThemeData(
      style: ButtonStyle(
        backgroundColor: MaterialStatePropertyAll(
          AppColors.primaryButtonColor,
        ),
      ),
    ),
  );
}


