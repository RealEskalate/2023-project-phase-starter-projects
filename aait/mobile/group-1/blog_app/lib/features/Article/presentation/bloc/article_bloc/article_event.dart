import 'package:blog_app/features/Article/domain/entities/create_article_entity.dart';
import 'package:blog_app/features/Article/domain/usecases/create_article.dart';

abstract class ArticleEvent {}

class CreateArticleEvent extends ArticleEvent {
  CreateArticleEntity article;
  CreateArticleEvent(this.article);
}

class UpdateArticleEvent extends ArticleEvent {
  CreateArticleEntity article;
  UpdateArticleEvent(this.article);
}

class GetArticleEvent extends ArticleEvent {
  String id;
  GetArticleEvent(this.id);
}
