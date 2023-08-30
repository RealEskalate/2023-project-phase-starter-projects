import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../../core/presentation/router/routes.dart';
import '../../../../../core/presentation/theme/app_colors.dart';
import '../../../../../core/utils/time_calculator.dart';
import '../../../../article/domain/entities/article.dart';
import '../../../../article/presentation/bloc/bookmark_bloc.dart';
import '../../../../authentication/presentation/bloc/auth_bloc.dart';
import '../../bloc/user_bloc.dart';

class SingleArticlePostListView extends StatelessWidget {
  final Article article;

  const SingleArticlePostListView({
    Key? key,
    required this.article,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double cardPadding = 20.w;
    double borderRadius = 16;
    double imageWidth = 92.w;
    double imageHeight = 141.w;
    double spacing = 20.w;
    double titleFontSize = 14.sp;
    double subTitleFontSize = 14.sp;
    double statsFontSize = 12.sp;
    double iconSize = 24.w;
    double statsSpacing = 6.w;

    const likes = '2.1k';

    final imageUrl = article.photoUrl;
    final articleTitle = article.title;
    final articleSubTitle = article.subTitle;
    final timeSincePosted =
        timePassedFormatter(timePassedCalculator(article.date));

    return GestureDetector(
      onTap: () async {
        final userBloc = context.read<UserBloc>();
        final authBloc = context.read<AuthBloc>();
        final bookmarkBloc = context.read<BookmarkBloc>();
        await context.push(Routes.articleDetail, extra: article);
        userBloc.add(GetUserEvent(token: authBloc.authToken));
        bookmarkBloc.add(LoadBookmarksEvent());
      },
      child: Padding(
        padding: EdgeInsets.only(bottom: cardPadding),
        child: Card(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(borderRadius),
          ),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              SizedBox(
                width: imageWidth,
                height: imageHeight,
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(borderRadius),
                  child: CachedNetworkImage(
                    imageUrl: imageUrl,
                    fit: BoxFit.cover,
                  ),
                ),
              ),
              SizedBox(width: spacing),
              Expanded(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      articleTitle,
                      style: TextStyle(
                        fontWeight: FontWeight.w100,
                        fontSize: titleFontSize,
                        color: AppColors.blue,
                      ),
                    ),
                    SizedBox(height: statsSpacing),
                    Text(
                      articleSubTitle,
                      style: TextStyle(
                        fontWeight: FontWeight.w500,
                        fontSize: subTitleFontSize,
                        color: AppColors.darkerBlue,
                      ),
                    ),
                    SizedBox(height: statsSpacing * 3),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            Icon(
                              Icons.thumb_up_alt_outlined,
                              color: AppColors.darkBlue,
                              size: iconSize,
                            ),
                            SizedBox(
                              width: statsSpacing,
                            ),
                            Text(
                              likes,
                              style: TextStyle(
                                fontSize: statsFontSize,
                                fontWeight: FontWeight.w500,
                                color: AppColors.darkBlue,
                              ),
                            ),
                          ],
                        ),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            Icon(
                              Icons.access_time,
                              color: AppColors.darkBlue,
                              size: iconSize,
                            ),
                            SizedBox(
                              width: statsSpacing,
                            ),
                            Text(
                              timeSincePosted,
                              style: TextStyle(
                                fontSize: statsFontSize,
                                fontWeight: FontWeight.w500,
                                color: AppColors.darkBlue,
                              ),
                            ),
                          ],
                        ),
                        Icon(
                          Icons.bookmark_outlined,
                          color: AppColors.blue,
                          size: iconSize,
                        ),
                      ],
                    )
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
