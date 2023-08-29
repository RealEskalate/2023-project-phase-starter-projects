// This screen represents the main HomeScreen of the blog app.
// It displays a list of articles and provides interaction options.

import 'package:blog_app/core/util/app_colors.dart';
import 'package:blog_app/features/article/presentation/bloc/article_bloc.dart';
import 'package:blog_app/features/article/presentation/widgets/loading_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

// Importing necessary widgets for the homepage.
import 'package:blog_app/features/article/presentation/widgets/blog_card_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/header_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/search_bar_widget.dart';
import 'package:blog_app/features/article/presentation/widgets/tags_widget.dart';
import 'package:go_router/go_router.dart';

import '../../data/models/user_model.dart';
import '../../domain/entity/article.dart';
import '../widgets/loading_widget.dart';

// ignore: must_be_immutable
class HomeScreen extends StatelessWidget {
  HomeScreen({super.key});

  List<Article> dummyArticles = [
    Article(
      tags: const ['Intership', 'Jobs'],
      content: '_empty.content',
      title: 'Student should apply for different intenships',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '30 min read',
      user: UserModel(
        fullName: "Tamirat Dereje",
        email: "tamiratdereje@gmail.com",
        expertise: "designer",
        bio: "I am passionate designer who see beauty in everything",
        createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
        image:
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        imageCloudinaryPublicId: "guf4tul1ftar9hdpnaev",
        id: "64e25674bfc65d390e781205",
      ),
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '1',
    ),
    Article(
      tags: const ['Sports', 'Sports'],
      content: '_empty.content',
      title: 'Student should Work On Improving their Wrting skills',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '1 hr read',
      user: UserModel(
        fullName: "Tamirat Dereje",
        email: "tamiratdereje@gmail.com",
        expertise: "designer",
        bio: "I am passionate designer who see beauty in everything",
        createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
        image:
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        imageCloudinaryPublicId: "guf4tul1ftar9hdpnaev",
        id: "64e25674bfc65d390e781205",
      ),
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '2',
    ),
    Article(
      tags: const ['Education', 'Education'],
      content: '_empty.content',
      title: 'Student should Work On Improving their Wrting skills',
      subTitle: '_empty.subTitle',
      estimatedReadTime: '5 min read',
      user: UserModel(
        fullName: "Tamirat Dereje",
        email: "tamiratdereje@gmail.com",
        expertise: "designer",
        bio: "I am passionate designer who see beauty in everything",
        createdAt: DateTime.parse('1969-07-20 20:18:04Z'),
        image:
            "https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg",
        imageCloudinaryPublicId: "guf4tul1ftar9hdpnaev",
        id: "64e25674bfc65d390e781205",
      ),
      image: '_empty.image',
      imageCloudinaryPublicId: '_empty.imageCloudinaryPublicId',
      createdAt: DateTime.parse('2023-08-20T19:36:03.414Z'),
      id: '3',
    ),
  ];

  List<String> tagNames = [
    'Sports',
    'Tech',
    'Politics',
    'Education',
  ];
  @override
  Widget build(BuildContext context) {
    // Scaffold with the primary color background.
    return Scaffold(
      backgroundColor: AppColors.primaryColor,
      body: Container(
        padding: EdgeInsets.all(16.w),
        child: SingleChildScrollView(
          child: SizedBox(
            height: 778.h,
            child: Column(
              children: [
                SizedBox(height: 56.h),
                // Header widget displaying the app title.
                const HeaderWidget(),
                SizedBox(height: 20.h),

                // Search bar widget for filtering articles.
                const SearchBarWidget(),
                SizedBox(height: 20.h),

                // List of tag buttons for article filtering.
                TagButtonListWidget(
                    tagNames:
                        tagNames // Dummy tags will be fetched from the database.
                    ),

                SizedBox(height: 15.h),

                // BlocConsumer<ArticleBloc, ArticleState>(
                //   listener: (context, state) {
                //     //  implement listener
                //   },
                //   builder: (context, state) {
                //     // Display filtered tasks
                //     if (state is ArticleLoaded && state.filteredArticles.isNotEmpty) {
                //       return Expanded(
                //         child: ListView.separated(
                //           itemCount: state.filteredArticles.length,
                //           separatorBuilder: (context, index) =>
                //               const SizedBox(height: 20),
                //           itemBuilder: (context, index) {
                //             return BlogCardWidget(
                //                 article: state.filteredArticles[index]);
                //           },
                //         ),
                //       );
                //     } else if (state is ArticleLoaded && state.articles.isNotEmpty) {
                //       // Display loaded tasks
                //       return Expanded(
                //         child: ListView.separated(
                //           itemCount: state.articles.length,
                //           separatorBuilder: (context, index) =>
                //               const SizedBox(height: 20),
                //           itemBuilder: (context, index) {
                //             return BlogCardWidget(
                //                 article: state.articles[index]);
                //           },
                //         ),
                //       );
                //     } else {
                //       // Display "No task" message
                //       return  const Expanded(
                // child:  LoadingWidget(message: "Loading"),
                // );
                //     }
                //   },
                // ),
                Expanded(
                  child: ListView.separated(
                    itemCount: dummyArticles.length,
                    separatorBuilder: (context, index) =>
                        const SizedBox(height: 20),
                    itemBuilder: (context, index) {
                      return BlogCardWidget(article: dummyArticles[index]);
                    },
                  ),
                ),
                
              ],
            ),
          ),
        ),
      ),

      // button for adding new articles.
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          context.go('/create_article');
        },
        label: Icon(
          Icons.add,
          size: 32.sp,
        ),
      ),
    );
  }
}
