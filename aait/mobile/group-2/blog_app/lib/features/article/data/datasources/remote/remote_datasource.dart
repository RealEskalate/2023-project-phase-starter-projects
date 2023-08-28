import '../../../domain/entities/tag.dart';
import '../../models/article_model.dart';
import '../../models/tag_model.dart';

abstract class ArticleRemoteDataSource {
  Future<List<ArticleModel>> getAllArticles();
  Future<List<ArticleModel>> filterArticles(Tag tag, String title);
  Future<List<TagModel>> getTags();
  Future<ArticleModel> getArticle(String id);
  Future<ArticleModel> createArticle(ArticleModel article);
  Future<ArticleModel> updateArticle(ArticleModel article);
  Future<ArticleModel> deleteArticle(String id);
}