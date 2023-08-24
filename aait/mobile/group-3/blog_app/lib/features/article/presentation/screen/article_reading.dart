import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/widgets.dart';


class ArticleReadingPage extends StatelessWidget {
  const ArticleReadingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return ScreenUtilInit(
      designSize: const Size(375, 812),
      builder: (BuildContext context, Widget? _) {
        return Scaffold(
          backgroundColor: Colors.white,
          appBar: PreferredSize(
            preferredSize: Size.fromHeight(74.h),
            child: const CustomAppBarArticleReading(),
          ),
          body: Stack(
            children: [
              SingleChildScrollView(
                child: SafeArea(
                  child: Column(
                    children: [
                      SizedBox(height: 24.h),
                      const HeadTitle(),
                      SizedBox(height: 24.h),
                      const UserInfo(),
                      SizedBox(height: 22.h),
                      const PostImage(),
                      SizedBox(height: 36.h),
                      const PostText(),
                      SizedBox(height: 80.h),
                    ],
                  ),
                ),
              ),
              const Positioned(
                bottom: 0,
                left: 0,
                right: 0,
                child: WhiteGradientOverlay(),
              ),
              Positioned(
                bottom: 44.h,
                right: 40.w,
                child: const CustomElevatedLikeButton(),
              )
            ],
          ),
        );
      },
    );
  }
}














