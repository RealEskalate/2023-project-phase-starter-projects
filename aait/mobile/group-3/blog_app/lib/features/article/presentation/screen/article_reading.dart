import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:top_snackbar_flutter/custom_snack_bar.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:top_snackbar_flutter/top_snack_bar.dart';

import '../../../../core/color/colors.dart';
import '../../../../core/util/value_converter.dart';
import '../bloc/article_bloc.dart';
import '../widgets/loading_widget.dart';
import '../../../../injection_container.dart';
import '../widgets/shimmer_article_reading_page.dart';
import '../widgets/widgets.dart';

class ArticleReadingPage extends StatefulWidget {
  final String id;

  const ArticleReadingPage({
    super.key,
    required this.id,
  });

  @override
  State<ArticleReadingPage> createState() => _ArticleReadingPageState();
}

class _ArticleReadingPageState extends State<ArticleReadingPage> {
  @override
  Widget build(BuildContext context) {
    return BlocProvider<ArticleBloc>(
      create: (_) => serviceLocator<ArticleBloc>(),
      child: BlocConsumer<ArticleBloc, ArticleState>(
        listener: (context, state) {
          if (state is ArticleError) {
            showTopSnackBar(
                Overlay.of(context),
                const CustomSnackBar.error(
                    message: "Oops unable to load the article"));
            context.go('/home');
          } else if (state is ArticleDeleted) {
            showTopSnackBar(
              Overlay.of(context),
              const CustomSnackBar.error(message: "Article Deleted"),
            );
            context.push('/home');
          }
        },
        builder: (context, state) {
          switch (state) {
            case ArticleError():
              return Scaffold(body: Text("Article reading error"),);
            case DeletingArticle():
              return const Scaffold(
                body: Scaffold(
                    body:
                        LoadingWidget(message: "Deleting article please wait")),
              );
            case GettingArticle():
              return Scaffold(body: LoadingArticlePage());
            // return const Scaffold(
            //     body: LoadingWidget(
            //   message: "Fetching Article please wait",
            // ));
            case ArticleInitial():
              BlocProvider.of<ArticleBloc>(context)
                  .add(GetArticleByIdEvent(id: this.widget.id));
              return Scaffold(body: LoadingArticlePage());
            // return const Scaffold(
            //     body: LoadingWidget(
            //   message: "Fetching Article please wait",
            // ));
            case ArticleLoaded():
              return ScreenUtilInit(
                designSize: const Size(375, 812),
                builder: (BuildContext context, Widget? _) {
                  return Scaffold(
                      backgroundColor: whiteColor,
                      appBar: AppBar(
                        backgroundColor: whiteColor,
                        elevation: 0,
                        leading: BackButton(
                          color: darkBlue,
                          onPressed: () => context.pop(),
                        ),
                        actions: [OptionsDialog(articleId: state.article.id)],
                      ),
                      body: Stack(
                        children: [
                          SingleChildScrollView(
                            child: SafeArea(
                              child: Column(
                                children: [
                                  SizedBox(height: 24.h),
                                  HeadTitle(headTitle: state.article.title),
                                  SizedBox(height: 24.h),
                                  UserInfo(
                                    article: state.article,
                                    authorName: state.article.user.fullName,
                                    postedAt: ValueConverter()
                                        .formatDate(state.article.createdAt),
                                    authorImageUrl: state.article.user.image,
                                  ),
                                  SizedBox(height: 22.h),
                                  PostImage(postImageUrl: state.article.image),
                                  SizedBox(height: 36.h),
                                  PostText(
                                    postText: state.article.content,
                                  ),
                                  SizedBox(height: 80.h),
                                ],
                              ),
                            ),
                          ),
                          const Positioned(
                            bottom: 0,
                            left: 0,
                            right: 0,
                            child: WhiteGradientOverlay(),
                          ),
                        ],
                      ),
                      floatingActionButton: FloatingActionButton.extended(
                        onPressed: () {
                          context.push('/home');
                        },
                        label: Icon(
                          Icons.home,
                          size: 32.sp,
                        ),
                      ));
                },
              );

            default:
              return Scaffold(
                  body: Center(
                    child: Text(
                        "Unimplemented state error from ArticleReadingPage $state"),
                  ),
                  floatingActionButton: FloatingActionButton.extended(
                    onPressed: () {
                      context.push('/home');
                    },
                    label: Icon(
                      Icons.home,
                      size: 32.sp,
                    ),
                  ));
          }
        },
      ),
    );
  }
}
