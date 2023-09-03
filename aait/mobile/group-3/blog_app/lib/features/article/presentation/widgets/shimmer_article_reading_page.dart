import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:shimmer/shimmer.dart';

class LoadingArticlePage extends StatefulWidget {
  const LoadingArticlePage({super.key});

  @override
  State<LoadingArticlePage> createState() => _LoadingArticlePageState();
}

class _LoadingArticlePageState extends State<LoadingArticlePage> {
  @override
  Widget build(BuildContext context) {
    return Shimmer.fromColors(
          baseColor: Colors.grey.shade300,
          highlightColor: Colors.grey.shade100,
          // enabled: true,
          child: SafeArea(
            child: SingleChildScrollView(
              physics: NeverScrollableScrollPhysics(),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                mainAxisSize: MainAxisSize.max,
                children: [
                  SizedBox(height: 100.h),
                  TitlePlaceholder(width: 160.w, isTitle: true,),
                  SizedBox(height: 24.h),
                  ContentPlaceholder(),
                  SizedBox(height: 22.h),
                  BannerPlaceholder(),
                  SizedBox(height: 36.h),
                  TitlePlaceholder(width: double.infinity),
                  SizedBox(height: 16.h),
                  TitlePlaceholder(width: double.infinity),
                  SizedBox(height: 16.h),
                  TitlePlaceholder(width: double.infinity),
                ],
              ),
            ),
          )
    );
  }
}


class TitlePlaceholder extends StatelessWidget {
  final double width;
  final bool isTitle;
  const TitlePlaceholder({
    Key? key,
    required this.width,
    this.isTitle = false,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: width,
            height: 14.h,
            color: Colors.white,
          ),
          if(!isTitle)
          SizedBox(height: 8.h),
          if(!isTitle)
          Container(
            width: 200.w,
            height: 14.h,
            color: Colors.white,
          ),

          
        ],
      ),
    );
  }
}


class ContentPlaceholder extends StatelessWidget {

  const ContentPlaceholder({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Row(
        mainAxisSize: MainAxisSize.max,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: 38.w,
            height: 38.h,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(12.r),
              color: Colors.white,
            ),
          ),
          SizedBox(width: 16.w),
          Expanded(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  width: 200.w,
                  height: 10.h,
                  color: Colors.white,
                  margin: const EdgeInsets.only(bottom: 8.0),
                ),
                  Container(
                    width: 100.w,
                    height: 10.h,
                    color: Colors.white,
                    margin: const EdgeInsets.only(bottom: 8.0),
                  ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Container(
                      width: 25.w,
                      height: 25.h,
                      color: Colors.white,
                    ),
                  ],
                )
              ],
            ),
          )
        ],
      ),
    );
  }
}


class BannerPlaceholder extends StatelessWidget {
  const BannerPlaceholder({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: 300.h,
      // margin: const EdgeInsets.all(16.0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.only(topLeft: Radius.circular(28.r), topRight: Radius.circular(28.r)),
        color: Colors.white,
      ),
    );
  }
}