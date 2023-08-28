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

import '../../domain/entity/article.dart';

// ignore: must_be_immutable
class HomeScreen extends StatelessWidget {
  HomeScreen({super.key});

  List<Article> dummyArticles = [
    Article(
      tags: const ['_empty.tags'],
      content: '_empty.content',
      title: '_empty.title',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '_empty.estimatedReadTime',
      user: const {
        "_id": "64e25674bfc65d390e781205",
        "fullName": "Tamirat Dereje",
        "email": "tamiratdereje@gmail.com",
        "expertise": "designer",
        "bio": "I am passionate designer who see beauty in everything",
        "createdAt": "2023-08-20T18:07:48.829Z",
        "__v": 0,
        "image":
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        "imageCloudinaryPublicId": "guf4tul1ftar9hdpnaev",
        "id": "64e25674bfc65d390e781205"
      },
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '1',
    ),
    Article(
      tags: const ['_empty.tags'],
      content: '_empty.content',
      title: '_empty.title',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '_empty.estimatedReadTime',
      user: const {
        "_id": "64e25674bfc65d390e781205",
        "fullName": "Tamirat Dereje",
        "email": "tamiratdereje@gmail.com",
        "expertise": "designer",
        "bio": "I am passionate designer who see beauty in everything",
        "createdAt": "2023-08-20T18:07:48.829Z",
        "__v": 0,
        "image":
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        "imageCloudinaryPublicId": "guf4tul1ftar9hdpnaev",
        "id": "64e25674bfc65d390e781205"
      },
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '2',
    ),
    Article(
      tags: const ['_empty.tags'],
      content: '_empty.content',
      title: '_empty.title',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '_empty.estimatedReadTime',
      user: const {
        "_id": "64e25674bfc65d390e781205",
        "fullName": "Tamirat Dereje",
        "email": "tamiratdereje@gmail.com",
        "expertise": "designer",
        "bio": "I am passionate designer who see beauty in everything",
        "createdAt": "2023-08-20T18:07:48.829Z",
        "__v": 0,
        "image":
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        "imageCloudinaryPublicId": "guf4tul1ftar9hdpnaev",
        "id": "64e25674bfc65d390e781205"
      },
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '3',
    ),
  ];
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

              ListView.separated(
                shrinkWrap: true,
                itemCount: dummyArticles.length,
                separatorBuilder: (context, index) =>
                    const SizedBox(height: 10),
                itemBuilder: (context, index) {
                  return BlogCardWidget(article: dummyArticles[index]);
                },
              ),
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
