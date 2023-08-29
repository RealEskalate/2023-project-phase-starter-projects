import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../injection_container.dart';

import '../../../authentication/presentation/bloc/auth_bloc.dart';
import '../../../user/presentation/bloc/user_bloc.dart';
import '../bloc/article_bloc.dart';
import '../bloc/tag_bloc.dart';
import '../widgets/widgets.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  //
  @override
  Widget build(BuildContext context) {
    //
    return BlocProvider<UserBloc>(
      create: (_) => serviceLocator<UserBloc>()
        ..add(
          GetUserEvent(token: BlocProvider.of<AuthBloc>(context).authToken),
        ),
      child: Scaffold(
        appBar: CustomAppBar(
          leading: SvgPicture.asset(
            'assets/svg/menu.svg',
            fit: BoxFit.scaleDown,
          ),
          title: 'Welcome Back!',
          actions: [
            BlocBuilder<UserBloc, UserState>(builder: (context, state) {
              if (state is LoadedUserState) {
                return GestureDetector(
                  onTap: () {
                    context.push(Routes.profileScreen);
                  },
                  child: ProfileAvatar(
                    image: state.userData.image,
                  ),
                );
              }
              return const Icon(Icons.person);
            }),
          ],
        ),
        body: MultiBlocProvider(
          providers: [
            BlocProvider(
              create: (context) =>
                  serviceLocator<ArticleBloc>()..add(LoadAllArticlesEvent()),
            ),
            BlocProvider(
              create: (context) =>
                  serviceLocator<TagBloc>()..add(LoadAllTagsEvent()),
            ),
          ],
          child: BlocBuilder<ArticleBloc, ArticleState>(
            builder: (context, _) => buildBody(context),
          ),
        ),
        floatingActionButton: FloatingActionButton(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(8.0),
          ),
          backgroundColor: AppColors.lightBlue,
          onPressed: () {
            context.push(Routes.createArticle);
          },
          child: const Icon(
            Icons.add,
            size: 35,
          ),
        ),
      ),
    );
  }

  Widget buildBody(BuildContext context) {
    return SingleChildScrollView(
      child: Container(
        height: MediaQuery.of(context).size.height - 100,
        padding: const EdgeInsets.all(20.0),
        color: Theme.of(context).colorScheme.background,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const CustomSearchBar(),
            const SizedBox(
              height: 20,
            ),

            BlocConsumer<TagBloc, TagState>(
              listener: (context, state) {
                if (state is TagErrorState) {
                  showError(context, state.message);
                }
              },
              builder: (context, state) {
                if (state is TagLoadingState) {
                  return const LoadingWidget();
                } else if (state is AllTagsLoadedState) {
                  return SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: TagList(tagList: state.tags));
                }
                return const LoadingWidget();
              },
            ),
            const SizedBox(
              height: 40,
            ),

            //
            BlocConsumer<ArticleBloc, ArticleState>(
              listener: (context, state) {
                if (state is ArticleErrorState) {
                  showError(context, state.message);
                }
              },
              builder: (context, state) {
                if (state is ArticleLoadingState) {
                  return const LoadingWidget();
                } else if (state is AllArticlesFilteredState) {
                  return ArticleList(articles: state.articles);
                } else if (state is AllArticlesLoadedState) {
                  return ArticleList(articles: state.articles);
                }
                return const LoadingWidget();
              },
            ),
          ],
        ),
      ),
    );
  }
}
