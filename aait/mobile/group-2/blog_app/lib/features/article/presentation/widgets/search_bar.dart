import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class CustomSearchBar extends StatelessWidget {
  const CustomSearchBar({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width - 20,
      height: 60.h,
      decoration: BoxDecoration(boxShadow: [
        BoxShadow(
          color: Colors.grey.withOpacity(0.5), // Shadow color
          spreadRadius: 1,
          blurRadius: 3,
          offset: const Offset(0, 1), // Offset in the x and y direction
        ),
      ], borderRadius: BorderRadius.circular(10.0), color: Colors.white),
      child: TextField(
        style: const TextStyle(
          color: AppColors.darkerBlue,
          fontFamily: 'Poppins',
          fontSize: 15,
        ),
        decoration: InputDecoration(
          hintText: 'Search an article...',
          hintStyle: const TextStyle(
            color: AppColors.gray300,
            fontFamily: 'Poppins',
            fontSize: 18,
            fontWeight: FontWeight.w200,
          ),
          suffixIcon: const SearchIcon(),
          border: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10.0),
            borderSide: const BorderSide(color: Colors.transparent),
          ),
          contentPadding: const EdgeInsets.fromLTRB(5.0, 10.0, 10.0, 0.0).w,
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10.0),
            borderSide: const BorderSide(color: AppColors.blue),
          ),
        ),
      ),
    );
  }
}

class SearchIcon extends StatelessWidget {
  const SearchIcon({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 60.h,
      width: 52.w,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10.0),
        color: AppColors.lightBlue,
      ),
      child: const Icon(
        Icons.search,
        size: 30,
        color: AppColors.white,
      ),
    );
  }
}
