import '../../models/article_model.dart';

abstract class ArticleLocalDataSource {
  Future<ArticleModel> getArticle(String id);
  Future<List<ArticleModel>> getArticles();
  Future<void> cacheArticle(ArticleModel article);
  Future<void> cacheArticles(List<ArticleModel> articles);
  Future<void> deleteArticle(String id);
}
