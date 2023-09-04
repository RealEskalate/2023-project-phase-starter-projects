import '../../models/article_model.dart';
import '../../models/tag_model.dart';

abstract class ArticleLocalDataSource {
  Future<List<TagModel>> getTags();
  Future<void> cacheTags(List<TagModel> tags);
  Future<ArticleModel> getArticle(String id);
  Future<List<ArticleModel>> getArticles();
  Future<void> cacheArticle(ArticleModel article);
  Future<void> cacheArticles(List<ArticleModel> articles);
}
