import 'package:blog_app/core/util/bookmark_preferences.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../core/color/colors.dart';

class UserInfo extends StatefulWidget {
  final String authorImageUrl;
  final String postedAt;
  final String authorName;
  final Article article;
  const UserInfo({
    required this.authorImageUrl,
    required this.postedAt,
    required this.authorName,
    required this.article,
    super.key,
  });

  @override
  State<UserInfo> createState() => _UserInfoState();
}

class _UserInfoState extends State<UserInfo> {
  bool isBookmarked = false;

  @override
  void initState() {
    super.initState();
    isBookmarked = BookmarkPreferences.isBookmarked(
        widget.article.user.id, widget.article.id);
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Container(
                height: 38.h,
                width: 38.w,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(12.r),
                  image: DecorationImage(
                    image: NetworkImage(
                      widget.authorImageUrl,
                    ),
                    fit: BoxFit.cover,
                  ),
                ),
              ),
              SizedBox(width: 16.w),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    widget.authorName,
                    style: GoogleFonts.urbanist(
                      fontSize: 14.sp,
                      fontWeight: FontWeight.w500,
                      color: darkBlueText,
                    ),
                  ),

                  // SizedBox(height: 6.h),
                  Text(
                    widget.postedAt,
                    style: GoogleFonts.poppins(
                      fontSize: 12.sp,
                      fontWeight: FontWeight.w900,
                      color: darkGrey,
                    ),
                  ),
                ],
              )
            ],
          ),
          IconButton(
              onPressed: () async {
                  await BookmarkPreferences.setBookmartk(
                      widget.article.user.id, widget.article.id);
                setState(() {
                  isBookmarked = BookmarkPreferences.isBookmarked(widget.article.user.id, widget.article.id);
                });
              },
              icon: Icon(
                isBookmarked?Icons.bookmark: Icons.bookmark_border,
                size: 24.sp,
                color: blue,
              ))
        ],
      ),
    );
  }
}
