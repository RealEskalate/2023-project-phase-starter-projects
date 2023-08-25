import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../bloc/profile_bloc.dart';
import 'grid_view_article_card.dart';
import 'list_view_article_card.dart';

class PostContent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final bloc = context.watch<ProfileBloc>();
    final state = bloc.state;

    switch (state) {
      case ProfileLoaded():
        final activeColor = blue;
        final inActiveColor = darkGrey;
        final stateIsGridView = state.isGridView;
        final stateIsBookmark = state.isBookmark;
        final article =
            stateIsBookmark ? state.profile.bookmarks : state.profile.articles;
        return Column(
          children: [
            Container(
              alignment: Alignment.centerLeft,
              padding: EdgeInsets.symmetric(horizontal: 32.w, vertical: 40.h),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    stateIsBookmark ? "Bookmarks" : "My Posts",
                    style:
                        TextStyle(fontWeight: FontWeight.w500, fontSize: 20.sp),
                  ),
                  Row(
                    children: [
                      IconButton(
                        onPressed: () {
                          bloc.add(ToggleViewMode(isGridView: true));
                        },
                        icon: Icon(Icons.grid_view),
                        color: stateIsGridView ? activeColor : inActiveColor,
                      ),
                      IconButton(
                        onPressed: () {
                          bloc.add(ToggleViewMode(isGridView: false));
                        },
                        icon: Icon(Icons.list),
                        color: stateIsGridView ? inActiveColor : activeColor,
                      )
                    ],
                  )
                ],
              ),
            ),
            !stateIsGridView
                ? ListView.builder(
                    shrinkWrap: true,
                    physics: NeverScrollableScrollPhysics(),
                    itemCount: article.length,
                    itemBuilder: (context, index) {
                      return ListViewArticleCard(
                        article: article[index],
                        isBookmarked: stateIsBookmark,
                      );
                    },
                  )
                : GridView.count(
                    shrinkWrap: true,
                    crossAxisCount: 2,
                    primary: false,
                    mainAxisSpacing: 20.h,
                    children: article
                        .map((e) => GridViewArticleCard(
                              article: e,
                              isBookmarked: stateIsBookmark,
                            ))
                        .toList(),
                  )
          ],
        );
      default:
        return const Text("UnrecognizedState");
    }
  }
}
