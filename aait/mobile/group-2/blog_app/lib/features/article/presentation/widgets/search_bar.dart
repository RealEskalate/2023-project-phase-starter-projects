import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

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
        decoration: InputDecoration(
          hintText: 'Search an article...',
          suffixIcon: const SearchIcon(),
          border: InputBorder.none,
          contentPadding: const EdgeInsets.fromLTRB(5.0, 10.0, 0.0, 0.0).w,
          focusedBorder: OutlineInputBorder(
            borderRadius: BorderRadius.circular(10.0),
            borderSide:
                BorderSide(color: Theme.of(context).colorScheme.primary),
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
          color: Theme.of(context).colorScheme.surface),
      child: const Icon(
        Icons.search,
        size: 30,
        color: Colors.white,
      ),
    );
  }
}
