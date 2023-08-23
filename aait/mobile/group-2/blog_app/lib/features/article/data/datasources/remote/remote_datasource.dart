import '../../models/article_model.dart';

abstract class ArticleRemoteDataSource {
  Future<List<ArticleModel>> getAllArticles();
  Future<ArticleModel> getArticle(String id);
  Future<ArticleModel> createArticle(ArticleModel article);
  Future<ArticleModel> updateArticle(ArticleModel article);
  Future<ArticleModel> deleteArticle(String id);
}