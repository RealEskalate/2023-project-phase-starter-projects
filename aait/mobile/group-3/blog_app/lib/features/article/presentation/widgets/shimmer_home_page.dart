import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:shimmer/shimmer.dart';

class LoadingHomeListPage extends StatefulWidget {
  const LoadingHomeListPage({super.key});

  @override
  State<LoadingHomeListPage> createState() => _LoadingHomeListPageState();
}

class _LoadingHomeListPageState extends State<LoadingHomeListPage> {
  @override
  Widget build(BuildContext context) {
    return Shimmer.fromColors(
          baseColor: Colors.grey.shade300,
          highlightColor: Colors.grey.shade100,
          // enabled: true,
          child: SingleChildScrollView(
            physics: const NeverScrollableScrollPhysics(),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisSize: MainAxisSize.max,
              children: [
                SizedBox(height: 12.h),
                const ContentPlaceholder(),
                SizedBox(height: 50.h),
                const ContentPlaceholder(),
                
              ],
            ),
          )
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
      padding: EdgeInsets.symmetric(horizontal: 16.h),
      child: Row(
        mainAxisSize: MainAxisSize.max,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: 160.w,
            height: 160.h,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(12.r),
              color: Colors.white,
            ),
          ),
          SizedBox(width: 12.w),
          Expanded(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  width: double.infinity,
                  height: 10.h,
                  color: Colors.white,
                  margin: const EdgeInsets.only(bottom: 8.0),
                ),
                  Container(
                    width: double.infinity,
                    height: 10.h,
                    color: Colors.white,
                    margin: const EdgeInsets.only(bottom: 8.0),
                  ),
                  Container(
                    width: double.infinity,
                    height: 10.h,
                    color: Colors.white,
                    margin: const EdgeInsets.only(bottom: 8.0),
                  ),
                  SizedBox(height: 12.h),
                  Container(
                  width: 100.w,
                  height: 10.h,
                  color: Colors.grey,
                ),
                SizedBox(height: 20.h),
                Container(
                  width: 100.w,
                  height: 10.h,
                  color: Colors.white,
                ),
                SizedBox(height: 80.h),
                Row(mainAxisAlignment: MainAxisAlignment.end,
                children: [Container(
                  width: 100.w,
                  height: 10.h,
                  color: Colors.white,
                ),],
                )
              ],
            ),
          )
        ],
      ),
    );
  }
}