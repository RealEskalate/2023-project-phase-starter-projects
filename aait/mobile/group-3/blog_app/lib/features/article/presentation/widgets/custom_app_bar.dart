import 'package:blog_app/features/profile/presentation/screen/profile_screen.dart';
import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';
import '../screen/article_reading.dart';
import '../screen/write_aricle_page.dart';

class CustomAppBarArticleReading extends StatefulWidget {
  const CustomAppBarArticleReading({
    super.key,
  });

  @override
  State<CustomAppBarArticleReading> createState() => _CustomAppBarArticleReadingState();
}

class _CustomAppBarArticleReadingState extends State<CustomAppBarArticleReading> {
  String _selectedValue = "";
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: AppBar(
        elevation: 0,
        toolbarHeight: 74.h,
        backgroundColor: Colors.white,
        leading: IconButton(
            onPressed: () {
              Navigator.pop(context);
              // Navigator.push(
              //   context,
              //   MaterialPageRoute(
              //     builder: (context) => ProfileScreen(),
              //   ),
            },
            padding: EdgeInsets.all(6.w),
            icon: const Icon(
              Icons.arrow_back_ios,
              color: darkBlue,
              size: 28,
            )),
            actions: [
            PopupMenuButton<String>(
              onSelected: (String value) {
                setState(() {
                  _selectedValue = value;
                });
              },
              itemBuilder: (BuildContext context) => [
                PopupMenuItem(
                  value: '1',
                  child: Text('Profile'),
                ),
                PopupMenuItem(
                  value: '2',
                  child: Text('Setting'),
                ),
                PopupMenuItem(
                  value: '3',
                  child: Text('Logout'),
                ),
              ],
        // actions: [
        //   IconButton(
        //       onPressed: () {},
        //       padding: EdgeInsets.all(6.w),
        //       icon: const Icon(
        //         Icons.more_horiz,
        //         color: darkBlue,
        //         size: 28,
        //       ))

              
        // ],
      ),
    );
  }
}

class CustomAppBarNewArticle extends StatelessWidget {
  const CustomAppBarNewArticle({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: AppBar(
        elevation: 0,
        toolbarHeight: 74.h,
        backgroundColor: Colors.white,
        centerTitle: true,
        leading: IconButton(
          onPressed: () {
            context.pop();
          },
          padding: EdgeInsets.all(6.w),
          icon: const Icon(
            Icons.arrow_back_ios,
            color: darkBlue,
            size: 28,
          ),
        ),
        title: Text(
          "New Article",
          style: GoogleFonts.poppins(
            fontSize: 24.sp,
            fontWeight: FontWeight.w500,
            color: darkBlue,
          ),
        ),
      ),
    );
  }
}

class CustomAppBarUpdateArticle extends StatelessWidget {
  const CustomAppBarUpdateArticle({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: AppBar(
        elevation: 0,
        toolbarHeight: 74.h,
        backgroundColor: Colors.white,
        centerTitle: true,
        leading: IconButton(
          onPressed: () {
            context.pop();
          },
          padding: EdgeInsets.all(6.w),
          icon: const Icon(
            Icons.arrow_back_ios,
            color: darkBlue,
            size: 28,
          ),
        ),
        title: Text(
          "Update Article",
          style: GoogleFonts.poppins(
            fontSize: 24.sp,
            fontWeight: FontWeight.w500,
            color: darkBlue,
          ),
        ),
      ),
    );
  }
}
