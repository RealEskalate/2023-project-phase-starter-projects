import '../repositories/article_repository.dart';

class GetTagsUseCase {
  final ArticleRepository repository;

  GetTagsUseCase(this.repository);

  Future<List<String>> call() async {
    return await repository.getTags();
  }
}
