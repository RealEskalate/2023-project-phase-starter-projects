import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';

class AuthorCard extends StatelessWidget {
  final String authorName;
  final String publishedAt;
  final String profileImageUrl;

  const AuthorCard({
    super.key,
    required this.authorName,
    required this.publishedAt,
    required this.profileImageUrl,
  });

  @override
  Widget build(BuildContext context) {
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
        const Icon(
          Icons.bookmark_border,
          size: 30,
          color: AppColors.blue,
        ),
      ],
    );
  }
}
