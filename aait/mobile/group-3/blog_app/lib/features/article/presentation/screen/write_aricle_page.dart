import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';
import '../widgets/widgets.dart';

class WriteArticlePage extends StatelessWidget {
  const WriteArticlePage({super.key});

  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
        designSize: const Size(428, 926),
        builder: (BuildContext context, child) {
          return Scaffold(
            backgroundColor: Colors.white,
            appBar: PreferredSize(
              preferredSize: Size.fromHeight(74.h),
              child: const CustomAppBarNewArticle(),
            ),
            body: Padding(
              padding: EdgeInsets.symmetric(horizontal: 45.w),
              child: SingleChildScrollView(
                child: SafeArea(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const CustomTextField(hint: "Add title"),
                      const CustomTextField(hint: "add subtitle"),
                      const AddTagsTextField(),
                      SizedBox(height: 4.39.h),
                      Text(
                        "add as many tags as you want",
                        style: GoogleFonts.poppins(
                          fontSize: 11.sp,
                          fontWeight: FontWeight.w200,
                          color: hintTextColor,
                        ),
                      ),
                      SizedBox(height: 49.h),
                      const ArticleContentTextField(),
                      SizedBox(height: 87.h),
                      const FormSubmitButton()
                    ],
                  ),
                ),
              ),
            ),
          );
        });
  }
}








