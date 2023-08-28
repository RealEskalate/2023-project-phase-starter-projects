import 'package:flutter/material.dart';

import '../../domain/entities/article.dart';
import 'article_card.dart';

class ArticleList extends StatelessWidget {
  final List<Article> articles;

  const ArticleList({required this.articles, super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.63,
      child: ListView.builder(
        itemCount: articles.length,
        itemBuilder: (context, index) {
          Article article = articles[index];
          return Padding(
              padding: const EdgeInsets.only(bottom: 15),
              child: ArticleCard(article: article));
        },
      ),
    );
  }
}
