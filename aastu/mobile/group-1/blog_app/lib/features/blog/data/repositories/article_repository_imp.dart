import 'package:blog_app/features/blog/data/datasources/remote_data_source.dart';
import 'package:blog_app/features/blog/data/models/blog_model.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/repositories/article_repository.dart';

class ArticleRepositoryImpl implements ArticleRepository {
  final RemoteDataSource remoteDataSource;

  ArticleRepositoryImpl(this.remoteDataSource);

  @override
  Future<BlogModel> getArticle(String articleId) async {
    final data = await remoteDataSource.fetchData('articles/$articleId');
    return BlogModel.fromJson(data['data']);
  }

  @override
  Future<void> deleteArticle(String articleId) async {
    // Implement the delete logic using the remote data source
  }

  @override
  Future<List<String>> getTags() async {
    final data = await remoteDataSource.fetchData('tags');
    return List<String>.from(data['data']);
  }

  @override
  Future<Article> getAllArticle() {
    // TODO: implement getAllArticle
    throw UnimplementedError();
  }

  @override
  Future<Article> getSingleArticle(String articleId) {
    // TODO: implement getSingleArticle
    throw UnimplementedError();
  }

  @override
  Future<void> createArticle(Article article) {
    // TODO: implement createArticle
    throw UnimplementedError();
  }

  @override
  Future<void> updateArticle(Article article) {
    // TODO: implement updateArticle
    throw UnimplementedError();
  }
}
