import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';
import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../injection_container.dart';
import '../../domain/entities/article.dart';
import '../bloc/article_bloc.dart';
import '../widgets/article_content.dart';
import '../widgets/article_image.dart';
import '../widgets/author_card.dart';
import '../widgets/gradient_scroll_view.dart';
import '../widgets/like_button.dart';
import '../widgets/snackbar.dart';
import '../widgets/widgets.dart';

class ArticleScreen extends StatelessWidget {
  final Article article;

  const ArticleScreen({super.key, required this.article});

  @override
  Widget build(BuildContext context) {
    return BlocProvider<ArticleBloc>(
      create: (_) => serviceLocator<ArticleBloc>(),
      child: BlocListener<ArticleBloc, ArticleState>(
        listener: (context, state) {
          if (state is ArticleErrorState) {
            showError(context, state.message);
          } else if (state is ArticleDeletedState) {
            context.pop();
          }
        },
        child: Scaffold(
          appBar: AppBar(
            backgroundColor: Theme.of(context).colorScheme.background,
            elevation: 0,
            actions: [
              BlocBuilder<ArticleBloc, ArticleState>(
                builder: (context, state) {
                  return _buildActions(context);
                },
              ),
            ],
          ),

          // body
          body: _buildBody(context),

          // Like button
          floatingActionButton: Transform.translate(
            offset: Offset(-20.w, -20.w),
            child: const LikeButton(likeCount: 2100),
          ),
        ),
      ),
    );
  }

  Widget _buildActions(BuildContext context) {
    return PopupMenuButton(
      onSelected: (value) {
        if (value == 'Edit') {
          context.push(Routes.editArticle, extra: article);
        } else if (value == 'Delete') {
          BlocProvider.of<ArticleBloc>(context).add(
            DeleteArticleEvent(article.id),
          );
        }
      },
      icon: const Icon(
        Icons.more_horiz,
        color: AppColors.darkerBlue,
      ),
      itemBuilder: (context) {
        return [
          const PopupMenuItem(
            value: 'Edit',
            child: Text('Edit'),
          ),
          const PopupMenuItem(
            value: 'Delete',
            child: Text('Delete'),
          ),
        ];
      },
    );
  }

  Widget _buildBody(BuildContext context) {
    return GradientScrollView(
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 10),
        child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
          // Article title
          Padding(
            padding: EdgeInsets.symmetric(horizontal: 40.w),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(article.title,
                    style: Theme.of(context).textTheme.titleLarge),

                SizedBox(height: 35.h),

                // Author card
                AuthorCard(
                  profileImageUrl: article.author.image,
                  authorName: article.author.fullName,
                  publishedAt: '2m ago',
                ),
              ],
            ),
          ),
          SizedBox(height: 30.h),

          // Article image
          ArticleImage(imageUrl: article.photoUrl),
          const SizedBox(height: 15),

          // Article content
          ArticleContent(
            paragraphs: [article.content],
          ),
          SizedBox(height: 100.h)
        ]),
      ),
    );
  }
}
