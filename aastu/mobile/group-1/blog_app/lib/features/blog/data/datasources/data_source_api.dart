import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:dartz/dartz.dart';

abstract class BlogRemoteDataSource {
  Future<List<Article>> getAllBlog();
  Future<void> postBlog(Map<String, dynamic> blogData);
  Future<void> deleteBlog(String articleId);
}

abstract class BlogRepository {
  Future<Either<Failure, List<Article>>> getAllArticles();
  Future<Either<Failure, void>> createArticle(Article article);
  Future<Either<Failure, void>> deleteArticle(String articleId);
}
