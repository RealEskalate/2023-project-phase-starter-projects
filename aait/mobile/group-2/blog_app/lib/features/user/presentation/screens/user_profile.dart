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

class UserProfile extends StatefulWidget {
  const UserProfile({super.key});

  @override
  State<UserProfile> createState() => _UserProfileState();
}

class _UserProfileState extends State<UserProfile> {
  bool grid = true;

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
                        child: BlocBuilder<UserBloc, UserState>(
                            builder: (context, state) {
                          if (state is LoadedUserState) {
                            return ShowPostsAndBookmarks(
                              numBookmarks: 0,
                              numPosts: state.userData.articles.length,
                            );
                          } else {
                            return const Center(
                                child: CircularProgressIndicator());
                          }
                        }),
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
                        child: BlocBuilder<UserBloc, UserState>(
                            builder: (context, state) {
                          if (state is LoadedUserState) {
                            return grid
                                ? ArticleGridView(
                                    articles: state.userData.articles,
                                    onGridView: switchView,
                                    onListView: switchView,
                                  )
                                : ArticleListView(
                                    articles: state.userData.articles,
                                    onGridView: switchView,
                                    onListView: switchView,
                                  );
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

  void switchView() {
    print(grid);
    setState(() {
      grid = !grid;
    });
  }
}
