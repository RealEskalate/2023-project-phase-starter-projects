import '../entities/article.dart';
import '../repositories/article_repository.dart';

class CreateArticleUseCase {
  final ArticleRepository repository;

  CreateArticleUseCase(this.repository);

  Future<void> call(Article article) async {
    await repository.createArticle(article);
  }
}
