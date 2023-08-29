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


class HomeScreen extends StatefulWidget {
  HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {


  void initState(){
    super.initState();
     BlocProvider.of<ArticleBloc>(context)
          .add(GetAllArticlesEvent());
  }
  List<String> tagNames = [
    "others",
        "sports",
        "oech",
        "politics",
        "art",
        "design",
        "culture",
        "production"
  ];

  @override
  Widget build(BuildContext context) {
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
                  SearchBarWidget(
                    searchByName: (queryString) {
                      BlocProvider.of<ArticleBloc>(context)
                          .add(GetAllArticlesEvent(searchQuery: queryString));
                    },
                  ),
                  SizedBox(height: 20.h),

                  // List of tag buttons for article filtering.
                  TagButtonListWidget(
                      tagNames:
                          tagNames ,
                          // Dummy tags will be fetched from the database.
                          SearchByTags: (curTag){
                             BlocProvider.of<ArticleBloc>(context)
                          .add(GetAllArticlesEvent(tags: [curTag]));
                          },
                      ),

                  SizedBox(height: 15.h),
                  BlocConsumer<ArticleBloc, ArticleState>(
                      listener: (context, state) {},
                      builder: (context, state) {
                        if (state is GettingArticles) {
                          return CircularProgressIndicator(
                            color: Colors.red,
                          );
                        } else if (state is ArticlesLoaded) {
                          return Expanded(
                              child: ListView.separated(
                            shrinkWrap: true,
                            itemCount: state.articles.length,
                            separatorBuilder: (context, index) =>
                                const SizedBox(height: 20),
                            itemBuilder: (context, index) {
                              return BlogCardWidget(
                                  article: state.articles[index]);
                            },
                          ));
                        } else {
                          return Center(
                            child: Text("Error while getting articles"),
                          );
                        }
                      })
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
        ));
  }
}
