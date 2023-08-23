import 'package:blog_application/core/exceptions/Failure.dart';
import 'package:dartz/dartz.dart';

import '../entities/article.dart';
abstract class ArticleRepository {
  Future<Either<Article, Failure>> getArticle(String id);
  Future<Either<List<Article>, Failure>> getArticles({List<String>? tags, String? searchParams});
  Future<Either<List<String>, Failure>> getTags();
  Future<Either<Article, Failure>> createArticle({String title, String content, List<String> tags, String subTitle, String? estimatedReadTime, String? image});
  Future<Either<Article, Failure>> updateArticle(Article article);
  Future<Either<void, Failure>> deleteArticle(String id);
  Future<Either<void, Failure>> bookmarkArticle(String id);
  Future<Either<void, Failure>> unBookmarkArticle(String id);
  Future<bool> isArticleBookmarked(String id);
}