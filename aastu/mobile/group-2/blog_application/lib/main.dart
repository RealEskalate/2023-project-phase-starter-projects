import 'package:flutter/material.dart';
import 'package:blog_application/features/blog/presentation/pages/articles_reading_screen.dart';

void main() {
  runApp(MaterialApp(
    debugShowCheckedModeBanner: false,
    home: ArticleReading(
      likes: 0,
    ),
  ));
}
