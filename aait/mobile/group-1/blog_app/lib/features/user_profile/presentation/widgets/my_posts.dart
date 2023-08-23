import 'package:flutter/material.dart';

import '../widgets/my_post.dart';

class MyPostsList extends StatefulWidget {
  const MyPostsList({
    super.key,
    required this.myPosts,
  });

  final List<MyPost> myPosts;

  @override
  State<MyPostsList> createState() => _MyPostsListState();
}

class _MyPostsListState extends State<MyPostsList> {
  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: ListView.builder(
        itemCount: widget.myPosts.length,
        itemBuilder: (BuildContext context, int index) {
          return widget.myPosts[index];
        },
      ),
    );
  }
}
