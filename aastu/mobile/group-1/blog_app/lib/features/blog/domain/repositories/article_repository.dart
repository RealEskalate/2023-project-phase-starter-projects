import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Article> getAllArticle();
  Future<Article> getSingleArticle(String articleId);
  Future<void> updateArticle(Article article);
  Future<void> createArticle(Article article);
  Future<void> deleteArticle(String articleId);
  Future<List<String>> getTags();
}
