import 'package:blog_app/features/Article/domain/entities/article_enitity.dart';

abstract class ArticleState {}

class Idle extends ArticleState {}

class Error extends ArticleState {}

class Loading extends ArticleState {}

class ArticleFetched extends ArticleState {
  Article article;
  ArticleFetched(this.article);
}
