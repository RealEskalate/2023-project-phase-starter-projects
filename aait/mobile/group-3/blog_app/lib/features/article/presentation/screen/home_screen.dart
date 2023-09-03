import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:loading_animation_widget/loading_animation_widget.dart';
import 'package:top_snackbar_flutter/custom_snack_bar.dart';
import 'package:top_snackbar_flutter/top_snack_bar.dart';

import '../../../../core/util/app_colors.dart';
import '../bloc/article_bloc.dart';
import '../widgets/blog_card_widget.dart';
import '../widgets/header_widget.dart';
import '../widgets/search_bar_widget.dart';
import '../widgets/tags_widget.dart';
import '../../../../core/color/colors.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  late ArticleBloc articleBloc;

  @override
  void initState() {
    super.initState();
    articleBloc = BlocProvider.of<ArticleBloc>(context);
    articleBloc.add(GetAllArticlesEvent());
    // BlocProvider.of<ArticleBloc>(context).add(GetAllArticlesEvent());
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
                  HeaderWidget(
                    callback: () {
                      context.push('/profile');
                    },
                  ),
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
                    tagNames: tagNames,
                    // Dummy tags will be fetched from the database.
                    SearchByTags: (curTag) {
                      BlocProvider.of<ArticleBloc>(context)
                          .add(GetAllArticlesEvent(tags: [curTag]));
                    },
                  ),

                  SizedBox(height: 15.h),
                  BlocConsumer<ArticleBloc, ArticleState>(
                      listener: (context, state) {},
                      builder: (context, state) {
                        if (state is ArticleDeleted) {
                          BlocProvider.of<ArticleBloc>(context)
                              .add(GetAllArticlesEvent());
                          showTopSnackBar(
                              Overlay.of(context),
                              const CustomSnackBar.error(
                                  message: "article deleted"));
                          return SizedBox.shrink();
                        } else if (state is ArticleInitial) {
                          BlocProvider.of<ArticleBloc>(context)
                              .add(GetAllArticlesEvent());
                          return LoadingAnimationWidget.discreteCircle(
                              color: blue, size: 60);
                        } else if (state is GettingArticles) {
                          return LoadingAnimationWidget.discreteCircle(
                              color: blue, size: 60);
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
                          return Scaffold(
                            body: Text("Error while getting articles$state"),
                            floatingActionButton: FloatingActionButton.extended(
                              onPressed: () {
                                context.push('/home');
                              },
                              label: Icon(
                                Icons.home,
                                size: 32.sp,
                              ),
                            ),
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
            context.push('/create_article');
          },
          label: Icon(
            Icons.add,
            size: 32.sp,
          ),
        ));
  }
}
