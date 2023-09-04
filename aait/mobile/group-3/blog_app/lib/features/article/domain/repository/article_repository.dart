import 'package:dartz/dartz.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/util/typedef.dart';
import '../entity/article.dart';
import '../entity/getArticlesEntity.dart';

abstract class ArticleRepository {
  //Create Article
  ResultFuture<Article> createArticle({
    required List<String> tags,
    required String content,
    required String title,
    required String subTitle,
    required String estimatedReadTime,
    required XFile image,
  });
  // Read Ariticle
  ResultFuture<List<Article>> getArticle({
    required String tags,
    required String searchParams,
  });
  ResultFuture<Article> getArticleById(String id);
  Future<Either<Failure, List<Article>>> getAllArticles(ArticleRequest articleRequest);
  // Update Article
  ResultFuture<Article> updateArticle({
    required List<String> tags,
    required String content,
    required String title,
    required String subTitle,
    required String estimatedReadTime,
    required XFile? image,
    required String id,
  });
  // Delete  Article
  ResultFuture<void> deleteArticle(String id);

  ResultFuture<List<String>> getTags();

}
