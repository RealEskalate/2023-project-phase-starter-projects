import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../injection_container.dart';
import '../../../article/presentation/bloc/bookmark_bloc.dart';
import '../../../article/presentation/widgets/snackbar.dart';
import '../../../authentication/presentation/bloc/auth_bloc.dart';
import '../bloc/profile_page_bloc.dart';
import '../bloc/user_bloc.dart';
import '../widgets/userprofile/article_grid_view.dart';
import '../widgets/userprofile/article_list_view.dart';
import '../widgets/userprofile/gradient_at_bottom.dart';
import '../widgets/userprofile/show_posts_and_bookmarks.dart';
import '../widgets/userprofile/user_profile_details.dart';

class UserProfile extends StatelessWidget {
  const UserProfile({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<UserBloc>(
          create: (context) => serviceLocator<UserBloc>()
            ..add(GetUserEvent(
                token: BlocProvider.of<AuthBloc>(context).authToken)),
        ),

        //
        BlocProvider(
            create: (context) =>
                serviceLocator<BookmarkBloc>()..add(LoadBookmarksEvent())),

        //
        BlocProvider(create: (context) => serviceLocator<ProfilePageBloc>()),
      ],

      //
      //
      child: BlocListener<AuthBloc, AuthState>(
        listener: (context, state) {
          if (state is LogoutSuccessState) {
            context.go(Routes.home);
          } else if (state is AuthError) {
            showError(context, 'Failed to logout');
          } else if (state is UserProfileUpdatedState) {
            context.read<UserBloc>().add(GetUserEvent(
                token: BlocProvider.of<AuthBloc>(context).authToken));
          }
        },
        child: Scaffold(
          appBar: AppBar(
              automaticallyImplyLeading: false,
              backgroundColor: AppColors.gray100,
              shadowColor: Colors.transparent,
              title: Container(
                color: AppColors.gray100,
                margin: EdgeInsets.fromLTRB(20.w, 24.h, 20.w, 24.h),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text('Profile',
                        style: Theme.of(context).textTheme.titleMedium),
                  ],
                ),
              ),
              actions: [
                PopupMenuButton(
                  onSelected: (value) {
                    if (value == 'logout') {
                      context.read<AuthBloc>().add(LogoutEvent());
                    }
                  },
                  icon: const Icon(
                    Icons.more_horiz,
                    color: AppColors.darkerBlue,
                  ),
                  itemBuilder: (context) {
                    return [
                      const PopupMenuItem(
                        value: 'logout',
                        child: Text('Logout'),
                      ),
                    ];
                  },
                ),
              ]),
          body: Stack(
            children: [
              SafeArea(
                child: SingleChildScrollView(
                  child: Column(
                    children: [
                      // const ProfileBar(),
                      BlocBuilder<UserBloc, UserState>(
                          builder: (context, state) {
                        if (state is LoadedUserState) {
                          return UserProfileDetails(user: state.userData);
                        } else {
                          return const Center(
                              child: CircularProgressIndicator());
                        }
                      }),
                      GestureDetector(
                        onTap: () {},

                        //
                        child: Center(
                          child: Transform.translate(
                            offset: Offset(0.w, -32.w),
                            child: BlocBuilder<UserBloc, UserState>(
                                builder: (context, userState) {
                              if (userState is LoadedUserState) {
                                return BlocBuilder<BookmarkBloc, BookmarkState>(
                                    builder: (context, bookmarkState) {
                                  if (bookmarkState is BookmarkLoadedState) {
                                    return ShowPostsAndBookmarks(
                                      numBookmarks:
                                          bookmarkState.articles.length,
                                      numPosts:
                                          userState.userData.articles.length,
                                    );
                                  }
                                  return ShowPostsAndBookmarks(
                                    numBookmarks: 0,
                                    numPosts:
                                        userState.userData.articles.length,
                                  );
                                });
                              } else {
                                return const Center(
                                    child: CircularProgressIndicator());
                              }
                            }),
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
                          child: BlocBuilder<ProfilePageBloc, ProfilePageState>(
                            builder: (context, state) {
                              if (state.showPost) {
                                return _showMyPosts(state.layout);
                              } else {
                                return _showBookmarks(state.layout);
                              }
                            },
                          ),
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
      ),
    );
  }

  Widget _showMyPosts(ProfileLayout layout) {
    return BlocBuilder<UserBloc, UserState>(
      builder: (context, state) {
        if (state is LoadedUserState) {
          return layout == ProfileLayout.list
              ? ArticleListView(
                  articles: state.userData.articles,
                  title: 'My Posts',
                )
              : ArticleGridView(
                  articles: state.userData.articles,
                  title: 'My Posts',
                );
        } else {
          return const Center(
            child: CircularProgressIndicator(),
          );
        }
      },
    );
  }

  Widget _showBookmarks(ProfileLayout layout) {
    return BlocBuilder<BookmarkBloc, BookmarkState>(
      builder: (context, state) {
        if (state is BookmarkLoadedState) {
          return layout == ProfileLayout.grid
              ? ArticleGridView(
                  articles: state.articles,
                  title: 'Bookmarks',
                )
              : ArticleListView(
                  articles: state.articles,
                  title: 'Bookmarks',
                );
        } else {
          return const Center(
            child: CircularProgressIndicator(),
          );
        }
      },
    );
  }
}
