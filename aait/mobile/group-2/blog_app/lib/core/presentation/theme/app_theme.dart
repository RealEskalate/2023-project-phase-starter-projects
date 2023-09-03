import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import 'app_colors.dart';

abstract class AppTheme {
  /// Theme data for the app
  ///
  /// This theme data is used in [App] widget
  static final themeData = ThemeData(
    // Color Palette
    colorScheme: const ColorScheme(
      primary: AppColors.blue,
      onPrimary: AppColors.white,
      secondary: AppColors.darkerBlue,
      onSecondary: AppColors.white,
      background: AppColors.gray100,
      onBackground: AppColors.darkBlue,
      surface: AppColors.gray200,
      onSurface: AppColors.darkBlue,
      error: AppColors.red,
      onError: AppColors.white,
      brightness: Brightness.light,
    ),

    // Text Theme
    textTheme: TextTheme(
      // Headings
      titleMedium: const TextStyle(
        color: AppColors.darkerBlue,
        fontFamily: 'Poppins',
        fontSize: 24,
        fontWeight: FontWeight.w500,
      ),
      titleLarge: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkerBlue,
        fontSize: 24,
        fontWeight: FontWeight.w600,
      ),

      // Body
      bodySmall: const TextStyle(
        color: AppColors.darkBlue,
        fontFamily: 'Poppins',
        fontSize: 14,
        fontWeight: FontWeight.w500,
      ),
      bodyMedium: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkBlue,
        fontSize: 16,
        fontWeight: FontWeight.w400,
      ),

      displayLarge: const TextStyle(
        fontWeight: FontWeight.w900,
        fontSize: 14,
        fontFamily: 'Poppins',
        color: AppColors.darkBlue,
      ),

      displayMedium: GoogleFonts.urbanist(
        fontSize: 24,
        fontWeight: FontWeight.w100,
      ),

      // Caption
      labelLarge: const TextStyle(
        fontFamily: 'Poppins',
        color: AppColors.darkGray,
        fontSize: 14,
        fontWeight: FontWeight.w900,
      ),
    ),

    // Elevated Button theme
    elevatedButtonTheme: const ElevatedButtonThemeData(
      style: ButtonStyle(
        textStyle: MaterialStatePropertyAll<TextStyle>(
          TextStyle(
            fontFamily: 'Poppins',
            fontSize: 15,
            fontWeight: FontWeight.w500,
            color: AppColors.white,
          ),
        ),
        shape: MaterialStatePropertyAll<RoundedRectangleBorder>(
          RoundedRectangleBorder(
            borderRadius: BorderRadius.all(
              Radius.circular(12),
            ),
          ),
        ),
      ),
    ),

    // Filled button theme
    filledButtonTheme: FilledButtonThemeData(
      style: ButtonStyle(
        backgroundColor: const MaterialStatePropertyAll(AppColors.gray200),
        foregroundColor: const MaterialStatePropertyAll(AppColors.gray300),
        alignment: Alignment.center,
        padding: const MaterialStatePropertyAll(EdgeInsets.zero),
        shape: MaterialStateProperty.all(
          const RoundedRectangleBorder(
            borderRadius: BorderRadius.all(
              Radius.circular(11),
            ),
          ),
        ),
      ),
    ),

    // Popup menu theme
    popupMenuTheme: const PopupMenuThemeData(
      color: AppColors.gray100,
      textStyle: TextStyle(
        color: AppColors.darkBlue,
        fontFamily: 'Poppins',
        fontSize: 14,
        fontWeight: FontWeight.w400,
      ),
    ),

    actionIconTheme: ActionIconThemeData(
      backButtonIconBuilder: (_) => Container(
        width: 36.h,
        height: 36.h,
        decoration: const BoxDecoration(
          color: AppColors.gray200,
          borderRadius: BorderRadius.all(
            Radius.circular(11),
          ),
        ),
        child: const Icon(Icons.chevron_left, color: AppColors.gray300),
      ),
    ),

    iconTheme: const IconThemeData(
      color: AppColors.darkBlue,
    ),
  );
}
