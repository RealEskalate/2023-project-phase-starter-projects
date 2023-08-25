import 'package:flutter/material.dart';

class BlogCardWidget extends StatelessWidget {
  const BlogCardWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Container(
        height: 240,
        decoration: BoxDecoration(
          color:
              Theme.of(context).cardColor, // Background color for the container
          borderRadius:
              BorderRadius.circular(15), // Rounded corners for the container
        ),
        padding: const EdgeInsets.all(16), // Padding for the content
        child: Stack(
          children: [
            const Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                BlogImageWidget(), // Widget for displaying the blog image
                SizedBox(width: 16), // Spacing between image and text
                BlogExcerptWidget(), // Widget for displaying blog excerpt
              ],
            ),
            Positioned(
              bottom: 0,
              right: 0,
              child: Text(
                "Jan 12,2022", // Publication date of the blog
                style: Theme.of(context).textTheme.labelSmall,
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class BlogExcerptWidget extends StatelessWidget {
  const BlogExcerptWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        padding: const EdgeInsets.all(8),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "STUDENTS SHOULD WORK ON IMPROVING THEIR WRITING SKILL", // Blog title
              style: Theme.of(context).textTheme.titleLarge,
              maxLines: 4,
              overflow: TextOverflow.ellipsis,
            ),
            const SizedBox(height: 8), // Spacing between title and category
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 4),
              decoration: BoxDecoration(
                color: Theme.of(context)
                    .disabledColor, // Background color for category box
                borderRadius: BorderRadius.circular(4),
              ),
              child: Text(
                "Education", // Category of the blog
                style: Theme.of(context).textTheme.displayLarge,
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
              ),
            ),
            const SizedBox(height: 8), // Spacing between category and author
            Text(
              "by John Doe", // Author of the blog
              style: Theme.of(context).textTheme.displayMedium,
              maxLines: 1,
              overflow: TextOverflow.ellipsis,
            ),
          ],
        ),
      ),
    );
  }
}

class BlogImageWidget extends StatelessWidget {
  const BlogImageWidget({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        ClipRRect(
          borderRadius:
              BorderRadius.circular(8), // Rounded corners for the image
          child: Image.asset(
            'images/avator.jpg', // Image asset for the blog
            width: 160,
            height: 160,
            fit: BoxFit.cover,
          ),
        ),
        Positioned(
          top: 8,
          left: 8,
          child: Container(
            padding: const EdgeInsets.symmetric(
              horizontal: 8,
              vertical: 4,
            ),
            decoration: BoxDecoration(
              color: Colors.white, // Background color for the "min read" label
              borderRadius: BorderRadius.circular(4),
            ),
            child: Text(
              "5 min read", // Estimated reading time
              style: Theme.of(context).textTheme.labelLarge,
            ),
          ),
        ),
      ],
    );
  }
}
