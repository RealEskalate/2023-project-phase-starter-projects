import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/widgets.dart';

class ArticleReadingPage extends StatelessWidget {
  final String headTitle;
  final String authorImageUrl;
  final String postedAt;
  final String authorName;
  final String postText;
  final String postImageUrl;
  final String likeCount;
  
  const ArticleReadingPage({
    super.key,
    required this.headTitle,
    required this.authorName,
    required this.postedAt,
    required this.authorImageUrl,
    required this.postText,
    required this.postImageUrl,
    required this.likeCount,
  });

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
                      HeadTitle(headTitle: headTitle),
                      SizedBox(height: 24.h),
                      UserInfo(
                        authorName: authorName,
                        postedAt: postedAt,
                        authorImageUrl: authorImageUrl,
                      ),
                      SizedBox(height: 22.h),
                      PostImage(postImageUrl: postImageUrl),
                      SizedBox(height: 36.h),
                      PostText(postText: postText,),
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
                child: CustomElevatedLikeButton(likeCount: likeCount),
              )
            ],
          ),
        );
      },
    );
  }
}
