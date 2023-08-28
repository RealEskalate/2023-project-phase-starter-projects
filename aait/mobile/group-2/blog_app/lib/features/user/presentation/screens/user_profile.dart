import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../injection_container.dart';
import '../bloc/user_bloc.dart';
import '../widgets/userprofile/article_grid_view.dart';
import '../widgets/userprofile/article_list_view.dart';
import '../widgets/userprofile/gradient_at_bottom.dart';
import '../widgets/userprofile/profile_bar.dart';
import '../widgets/userprofile/show_posts_and_bookmarks.dart';
import '../widgets/userprofile/user_profile_details.dart';

class UserProfile extends StatelessWidget {
  final List<ArticleData> articles = [
    ArticleData(
      imageUrl:
          'https://www.bigdataframework.org/wp-content/uploads/2019/11/2.jpg',
      articleTitle: "BIG DATA",
      articleSubTitle: "Why Big Data Needs Thick Data?",
      likes: "2.1k",
      timeSincePosted: 1,
    ),
    ArticleData(
      imageUrl:
          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqGXmKLCVl1gZpK258cXN-p4l68VKeqwwkTKr1vB4P&s',
      articleTitle: "UX DESIGN",
      articleSubTitle: "Step design sprint for UX beginner",
      likes: "1.1k",
      timeSincePosted: 3,
    ),
    ArticleData(
      imageUrl:
          'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqGXmKLCVl1gZpK258cXN-p4l68VKeqwwkTKr1vB4P&s',
      articleTitle: "UX DESIGN",
      articleSubTitle: "Step design sprint for UX beginner",
      likes: "1.1k",
      timeSincePosted: 3,
    ),
  ];

  UserProfile({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider<UserBloc>(
      create: (context) => serviceLocator(),
      child: Scaffold(
        body: Stack(
          children: [
            SafeArea(
              child: SingleChildScrollView(
                child: Column(
                  children: [
                    const ProfileBar(),
                    BlocBuilder<UserBloc, UserState>(builder: (context, state) {
                      if (state is LoadedUserState) {
                        return UserProfileDetails(user: state.userData);
                      } else {
                        return const Center(child: CircularProgressIndicator());
                      }
                    }),
                    Center(
                      child: Transform.translate(
                        offset: Offset(0.w, -32.w),
                        child: const ShowPostsAndBookmarks(
                          numBookmarks: 12,
                          numPosts: 52,
                        ),
                      ),
                    ),
                    Container(
                      decoration: BoxDecoration(
                          color: Colors.white,
                          borderRadius: BorderRadius.circular(28.0),
                          border: Border.all(
                            color: Colors.grey,
                            width: 0.025,
                          )),
                      child: Container(
                        padding: const EdgeInsets.fromLTRB(40, 32, 30, 27),
                        child:
                            // ArticleGridView(articles: articles),
                            ArticleListView(articles: articles),
                      ),
                    )
                  ],
                ),
              ),
            ),
            const GradientAtBottom()
          ],
        ),
      ),
    );
  }
}
