import 'package:blog_app/features/user/presentation/widgets/userprofile/show_posts_or_bookmarks_button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ShowPostsAndBookmarks extends StatelessWidget {
  final int numPosts, numBookmarks;
  final Function(String) handlePostChoice;
  final String currPosts;

  ShowPostsAndBookmarks({
    Key? key,
    required this.numPosts,
    required this.numBookmarks,
    required this.handlePostChoice,
    required this.currPosts,
  }) : super(key: key);

  Color col1 = Color(0xFF2151CD);
  Color col2 = Color(0xFF386BED);

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
          color: col2,
        ),
        child: Row(
          children: [
            GestureDetector(
              behavior: HitTestBehavior.deferToChild,
              onTap: () => handlePostChoice('Posts'),
              child: Container(
                child: ShowPostsOrBookmarksButton(
                  count: numPosts,
                  col: currPosts == 'Posts' ? col1 : col2,
                  typeOfChoice: 'Posts',
                ),
              ),
            ),
            GestureDetector(
              behavior: HitTestBehavior.opaque,
              onTap: () => handlePostChoice('Bookmarks'),
              child: Container(
                child: ShowPostsOrBookmarksButton(
                  count: numBookmarks,
                  col: currPosts == "Bookmarks" ? col1 : col2,
                  typeOfChoice: 'Bookmarks',
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
