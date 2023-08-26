// This screen represents the main HomeScreen of the blog app.
// It displays a list of articles and provides interaction options.

import 'package:blog_app/core/util/app_colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

// Importing necessary widgets for the homepage.
import 'package:blog_app/features/article/presentation/widgets/blog_card_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/header_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/search_bar_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/tags_widget.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    // Scaffold with the primary color background.
    return Scaffold(
      backgroundColor: AppColors.primaryColor,

      // Scrollable body content.
      body: SingleChildScrollView(
        child: Container(
          padding: EdgeInsets.all(16.w),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              SizedBox(height: 56.h),

              // Search bar widget for filtering articles.
              const SearchBarWidget(),
              SizedBox(height: 20.h),

              // Header widget displaying the app title.
              const HeaderWidget(),
              SizedBox(height: 20.h),

              // List of tag buttons for article filtering.
              const TagButtonListWidget(
                tagNames: [
                  'Sports',
                  'Tech',
                  'Politics',
                  'Education',
                ], // Dummy tags will be fetched from the database.
              ),
              SizedBox(height: 50.h),

              // List of blog cards displaying articles.
              const BlogCardWidget(),
            ],
          ),
        ),
      ),

      // button for adding new articles.
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          Navigator.pushNamed(context, '/create-article');
        },
        label: Icon(
          Icons.add,
          size: 32.sp,
        ),
      ),
    );
  }
}
