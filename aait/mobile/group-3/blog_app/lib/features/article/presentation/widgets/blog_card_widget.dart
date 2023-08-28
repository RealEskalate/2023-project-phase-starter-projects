import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/util/app_colors.dart';
import '../../domain/entity/article.dart';

class BlogCardWidget extends StatelessWidget {
  const BlogCardWidget({super.key, required this.article});

  final Article article;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        // raise load article by id event
        // Navigator.pushNamed(context, '/article-detail');
      },
      child: Container(
        height: 240.h,
        width: 388.w,
        decoration: BoxDecoration(
          color: AppColors.whiteColor, // Background color for the container
          borderRadius:
              BorderRadius.circular(15), // Rounded corners for the container
        ),
        padding: EdgeInsets.all(11.sp), // Padding for the content
        child: Stack(
          children: [
            Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const BlogImageWidget(), // Widget for displaying the blog image
                SizedBox(width: 16.w), // Spacing between image and text
                BlogExcerptWidget(
                  article: article,
                ), // Widget for displaying blog excerpt
              ],
            ),
            Positioned(
              bottom: 0,
              right: 0,
              child: Text(
                "Jan 12,2022", // Publication date of the blog
                style: TextStyle(
                  fontFamily: 'Poppins-Light',
                  color: AppColors.textLightGray,
                  fontSize: 12.sp,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class BlogExcerptWidget extends StatelessWidget {
  BlogExcerptWidget({
    super.key,
    required this.article,
  });

  Article article;

  List<String> tags = ["education", "Entertainment", "education", "Entertainment",];

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        padding: const EdgeInsets.all(8),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "STUDENTS SHOULD WORK ON IMPROVING THEIR WRITING SKILL", // Blog title
              style: TextStyle(
                fontFamily: 'Urbanist-Regular',
                fontSize: 17.sp,
                fontWeight: FontWeight.w400,
                height: 1,
              ),
              maxLines: 4,
              overflow: TextOverflow.ellipsis,
            ),
            SizedBox(height: 8.h), // Spacing between title and category
            SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Row(
                children: [
                  ...tags.map(
                    (tagName) {
                      return Container(
                        margin: const EdgeInsets.only(right: 12),
                        padding: EdgeInsets.symmetric(
                            horizontal: 8.w, vertical: 4.h),
                        decoration: BoxDecoration(
                          color: AppColors
                              .disabledButtonColor, // Background color for category box
                          borderRadius: BorderRadius.circular(4),
                        ),
                        child: Text(
                          "Education", // Category of the blog
                          style: TextStyle(
                            fontFamily: 'Poppins-SemiBold',
                            color: AppColors.whiteColor,
                            fontSize: 13.sp,
                          ),
                          maxLines: 1,
                          overflow: TextOverflow.ellipsis,
                        ),
                      );
                    },
                  ),
                ],
              ),
            ),
            SizedBox(height: 8.h), // Spacing between category and author
            Text(
              "john Doe", // Author of the blog
              style: TextStyle(
                fontFamily: 'Poppins-Regular',
                color: AppColors.primaryTextGray,
                fontSize: 14.sp,
              ),

              maxLines: 1,
              overflow: TextOverflow.ellipsis,
            ),
          ],
        ),
      ),
    );
  }
}

class BlogImageWidget extends StatelessWidget {
  const BlogImageWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        ClipRRect(
          borderRadius:
              BorderRadius.circular(8), // Rounded corners for the image
          child: Image.asset(
            'images/avator.jpg', // Image asset for the blog
            width: 160.w,
            height: 160.h,
            fit: BoxFit.cover,
          ),
        ),
        Positioned(
          top: 8,
          left: 8,
          child: Container(
            padding: EdgeInsets.symmetric(
              horizontal: 8.w,
              vertical: 4.h,
            ),
            decoration: BoxDecoration(
              color: Colors.white, // Background color for the "min read" label
              borderRadius: BorderRadius.circular(4),
            ),
            child: const Text(
              "5 min read", // Estimated reading time
              style: TextStyle(
                fontFamily: 'Poppins-Medium',
                color: AppColors.primaryTextGray,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
