import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../../../core/utils/time_calculator.dart';
import '../../domain/entities/article.dart';
import '../bloc/bookmark_bloc.dart';

class AuthorCard extends StatelessWidget {
  final Article article;
  final bool isBookmarked;

  const AuthorCard(
      {super.key, required this.article, required this.isBookmarked});

  @override
  Widget build(BuildContext context) {
    final profileImageUrl = article.author.image;
    final authorName = article.author.fullName;
    final publishedAt = timePassedFormatter(timePassedCalculator(article.date));

    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Row(
          children: [
            // avatar
            CircleAvatar(
              backgroundImage: CachedNetworkImageProvider(profileImageUrl),
            ),

            const SizedBox(width: 10),

            // author name and time
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  authorName,
                  style: Theme.of(context).textTheme.bodySmall,
                ),
                Text(publishedAt,
                    style: Theme.of(context).textTheme.labelLarge),
              ],
            ),
          ],
        ),

        // bookmark icon
        GestureDetector(
          onTap: () => _changeBookmarkStatus(context),
          child: Icon(
            Icons.bookmark_border,
            size: 30,
            color: isBookmarked ? AppColors.blue : AppColors.gray300,
          ),
        ),
      ],
    );
  }

  void _changeBookmarkStatus(BuildContext context) {
    if (isBookmarked) {
      context.read<BookmarkBloc>().add(RemoveFromBookmarkEvent(article.id));
    } else {
      context.read<BookmarkBloc>().add(AddToBookmarkEvent(article));
    }
  }
}
