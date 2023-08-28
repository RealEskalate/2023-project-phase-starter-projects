import 'package:blog_app/features/user/presentation/widgets/post_list.dart';
import 'package:flutter/material.dart';

Widget blogListView() {
  return ListView.builder(
    itemCount: blogs.length,
    itemBuilder: (context, index) {
      return BlogCards(index: index, object: blogs[index]);
    },
  );
}
