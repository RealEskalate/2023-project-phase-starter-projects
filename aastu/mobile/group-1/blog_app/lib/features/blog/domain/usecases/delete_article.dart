import '../repositories/article_repository.dart';

class DeleteArticleUseCase {
  final ArticleRepository repository;

  DeleteArticleUseCase(this.repository);

  Future<void> call(String articleId) async {
    return await repository.deleteArticle(articleId);
  }
}
