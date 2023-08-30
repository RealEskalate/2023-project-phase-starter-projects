import 'package:blog_app/core/color/colors.dart';
import 'package:blog_app/core/util/value_converter.dart';
import 'package:blog_app/features/article/presentation/bloc/article_bloc.dart';
import 'package:blog_app/features/profile/presentation/widgets/loading_widget.dart';
import 'package:blog_app/injection_container.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../widgets/widgets.dart';

class ArticleReadingPage extends StatelessWidget {
  final String id;

  const ArticleReadingPage({
    super.key,
    required this.id,
  });

  @override
  Widget build(BuildContext context) {
    return BlocProvider<ArticleBloc>(
      create: (_) => serviceLocator<ArticleBloc>(),
      child: BlocConsumer<ArticleBloc, ArticleState>(
        builder: (context, state) {
          switch (state) {
            case GettingArticle():
              return Scaffold(
                  body: LoadingWidget(
                message: "Fetching Article please wait",
              ));
            case ArticleInitial():
              BlocProvider.of<ArticleBloc>(context)
                  .add(GetArticleByIdEvent(id: this.id));
              return Scaffold(
                  body: LoadingWidget(
                message: "Fetching Article please wait",
              ));
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
                  );
                },
              );

            default:
              return Scaffold(
                body: Center(
                  child: Text(
                      "Unimplemented state error from ArticleReadingPage $state"),
                ),
              );
          }
        },
        listener: (context, state) {},
      ),
    );
  }
}
