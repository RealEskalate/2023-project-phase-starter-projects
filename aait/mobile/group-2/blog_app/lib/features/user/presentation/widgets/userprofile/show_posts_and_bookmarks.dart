import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../../core/presentation/theme/app_colors.dart';
import '../../bloc/profile_page_bloc.dart';
import 'show_posts_or_bookmarks_button.dart';

class ShowPostsAndBookmarks extends StatelessWidget {
  final int numPosts, numBookmarks;

  const ShowPostsAndBookmarks({
    Key? key,
    required this.numPosts,
    required this.numBookmarks,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);
    double elevation = 32.h;

    return Material(
      elevation: elevation,
      borderRadius: BorderRadius.circular(12.0),
      child: Container(
        width: 230.w,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(12.0),
          color: AppColors.saturatedBlue200,
        ),
        child: Row(
          children: [
            BlocBuilder<ProfilePageBloc, ProfilePageState>(
              builder: (context, state) {
                return state.showPost
                    ? Row(children: [
                        ShowPostsOrBookmarksButton(
                          count: numPosts,
                          col: AppColors.saturatedBlue300,
                          typeOfChoice: 'Posts',
                        ),
                        ShowPostsOrBookmarksButton(
                          count: numBookmarks,
                          col: AppColors.saturatedBlue200,
                          typeOfChoice: 'Bookmarks',
                        ),
                      ])
                    : Row(
                        children: [
                          ShowPostsOrBookmarksButton(
                            count: numPosts,
                            col: AppColors.saturatedBlue200,
                            typeOfChoice: 'Posts',
                          ),
                          ShowPostsOrBookmarksButton(
                            count: numBookmarks,
                            col: AppColors.saturatedBlue300,
                            typeOfChoice: 'Bookmarks',
                          ),
                        ],
                      );
              },
            ),
          ],
        ),
      ),
    );
  }
}
