import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../widgets/article_content.dart';
import '../widgets/article_image.dart';
import '../widgets/author_card.dart';
import '../widgets/gradient_scroll_view.dart';
import '../widgets/like_button.dart';

class ArticleScreen extends StatelessWidget {
  final String articleId;

  const ArticleScreen({super.key, required this.articleId});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.background,
        elevation: 0,
        actions: _buildActions(context),
      ),

      // body
      body: _buildBody(context),

      // Like button
      floatingActionButton: Transform.translate(
        offset: Offset(-20.w, -20.w),
        child: const LikeButton(likeCount: 2100),
      ),
    );
  }

  List<Widget> _buildActions(BuildContext context) {
    return [
      PopupMenuButton(
        icon: const Icon(
          Icons.more_horiz,
          color: AppColors.darkerBlue,
        ),
        itemBuilder: (context) {
          return [
            const PopupMenuItem(
              child: Text('Edit'),
            ),
            const PopupMenuItem(
              child: Text('Delete'),
            ),
          ];
        },
      ),
    ];
  }

  Widget _buildBody(BuildContext context) {
    return GradientScrollView(
      child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
        // Article title
        Padding(
          padding: EdgeInsets.symmetric(horizontal: 40.w),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text('Four Things Every One Needs To Know',
                  style: Theme.of(context).textTheme.titleLarge),

              SizedBox(height: 35.h),

              // Author card
              const AuthorCard(
                profileImageUrl:
                    'https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg',
                authorName: 'Richard Gervain',
                publishedAt: '2m ago',
              ),
            ],
          ),
        ),
        SizedBox(height: 30.h),

        // Article image
        const ArticleImage(
            imageUrl:
                'https://res.cloudinary.com/dzpmgwb8t/image/upload/v1692557684/guf4tul1ftar9hdpnaev.jpg'),
        const SizedBox(height: 15),

        // Article content
        const ArticleContent(
          paragraphs: [
            'That marked a turnaround from last year, when the social network reported a decline in users for the first time.',
            'The drop wiped billions from the firm\'s market value.',
            'Since executives disclosed the fall in February, the firm\'s share price has nearly halved. But shares jumped 19% in after-hours trade on Wednesday.',
          ],
        ),
        SizedBox(height: 100.h)
      ]),
    );
  }
}
