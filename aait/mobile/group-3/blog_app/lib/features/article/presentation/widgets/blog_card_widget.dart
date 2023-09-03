import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:intl/intl.dart';
// import 'package:timeago/timeago.dart' as timeago;

import '../../../../core/util/app_colors.dart';
import '../../domain/entity/article.dart';

class BlogCardWidget extends StatelessWidget {
  const BlogCardWidget({super.key, required this.article});

  final Article article;

  @override
  Widget build(BuildContext context) {
    DateTime postDate = article.createdAt; // Replace with your blog post's actual date

    String formattedDate = DateFormat('MMM d, yyyy').format(postDate);
    // String relativeTime = timeago.format(postDate);
    return SingleChildScrollView(
      child: GestureDetector(

        onTap: () {
          context.push('/article', extra: article.id);
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
                  BlogImageWidget(
                      article: article), // Widget for displaying the blog image
                  SizedBox(width: 16.w), // Spacing between image and text
                  BlogExcerptWidget(
                      article: article), // Widget for displaying blog excerpt
                ],
              ),
              Positioned(
                bottom: 0,
                right: 0,
                child: Text(
                  formattedDate, // Publication date of the blog
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
      ),
    );
  }
}

class BlogExcerptWidget extends StatelessWidget {
  final Article article;
  const BlogExcerptWidget({
    super.key,
    required this.article,
  });

  @override
  Widget build(BuildContext context) {
    List<String> tags = article.tags.isNotEmpty
        ? article.tags
        : [
            "Education",
            "Entertainment",
            "Education",
            "Entertainment",
          ];
    return Expanded(
      child: Container(
        padding: const EdgeInsets.all(8),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              article.title.toUpperCase(), // Blog title
              style: TextStyle(
                fontFamily: 'Urbanist-Regular',
                fontSize: 17.sp,
                fontWeight: FontWeight.w400,
                height: 1.2,
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
                          tagName, // Category of the blog
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
              "By ${article.user.fullName}", // Author of the blog
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
  final Article article;

  const BlogImageWidget({super.key, required this.article});

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        ClipRRect(
          borderRadius:
              BorderRadius.circular(8), // Rounded corners for the image
          
          child: Image.network(
           article.image, // Replace with the actual image URL
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
            child: Text(
              article.estimatedReadTime, // Estimated reading time
              style: const TextStyle(
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
