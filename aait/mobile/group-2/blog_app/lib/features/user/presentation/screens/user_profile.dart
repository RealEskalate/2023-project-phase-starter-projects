import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../injection_container.dart';
import '../../../authentication/presentation/bloc/auth_bloc.dart';
import '../bloc/user_bloc.dart';
import '../widgets/userprofile/article_list_view.dart';
import '../widgets/userprofile/gradient_at_bottom.dart';
import '../widgets/userprofile/profile_bar.dart';
import '../widgets/userprofile/show_posts_and_bookmarks.dart';
import '../widgets/userprofile/user_profile_details.dart';

class UserProfile extends StatelessWidget {
  const UserProfile({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider<UserBloc>(
      create: (context) => serviceLocator<UserBloc>()
        ..add(
            GetUserEvent(token: BlocProvider.of<AuthBloc>(context).authToken)),
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
                            BlocBuilder<UserBloc, UserState>(
                                builder: (context, state) {
                          if (state is LoadedUserState) {
                            return ArticleListView(
                                articles: state.userData.articles);
                          } else {
                            return const Center(
                                child: CircularProgressIndicator());
                          }
                        }),
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
