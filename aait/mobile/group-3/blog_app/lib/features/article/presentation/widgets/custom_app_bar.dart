import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';
import '../screen/article_reading.dart';
import '../screen/write_aricle_page.dart';

class CustomAppBarArticleReading extends StatelessWidget {
  const CustomAppBarArticleReading({
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
        leading: IconButton(
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => WriteArticlePage(),
                ),
              );
            },
            padding: EdgeInsets.all(6.w),
            icon: const Icon(
              Icons.arrow_back_ios,
              color: darkBlue,
              size: 28,
            )),
        actions: [
          IconButton(
              onPressed: () {},
              padding: EdgeInsets.all(6.w),
              icon: const Icon(
                Icons.more_horiz,
                color: darkBlue,
                size: 28,
              ))
        ],
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
            Navigator.push(
                context,
                MaterialPageRoute(
                    builder: (context) => const ArticleReadingPage()));
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
