import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticleUseCase {
  final ArticleRepository repository;

  GetArticleUseCase(this.repository);

  Future<Article> call(String articleId) async {
    return await repository.getAllArticle();
  }
}
