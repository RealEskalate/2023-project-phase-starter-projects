import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

import '../../../../core/presentation/router/routes.dart';

class LikeButton extends StatelessWidget {
  final int likeCount;
  final VoidCallback? onPressed;

  const LikeButton({super.key, required this.likeCount, this.onPressed});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: 111,
      height: 48,
      child: ElevatedButton(
        onPressed: () {
          context.push(Routes.createArticle);
        },
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Icon(Icons.thumb_up_outlined),
            const SizedBox(width: 5),
            Text(
              // TODO: Implement like count to string function
              // likeCount.toString(),
              '2.1k',
              style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                    color: Theme.of(context).colorScheme.onPrimary,
                    fontWeight: FontWeight.w500,
                  ),
            ),
          ],
        ),
      ),
    );
  }
}
