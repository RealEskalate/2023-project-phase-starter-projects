import 'package:blog_app/core/constants/constants.dart';
import 'package:blog_app/core/network/custom_client.dart';
import 'package:blog_app/features/article/data/datasources/remote/remote_datasource_impl.dart';
import 'package:blog_app/features/article/data/models/article_model.dart';
import 'package:blog_app/features/article/domain/entities/tag.dart';
import 'package:blog_app/features/user/domain/entities/user_data.dart';
import 'package:http/http.dart' as http;

CustomClient client = CustomClient(http.Client(), apiBaseUrl: apiBaseUrl);

final repo = ArticleRemoteDataSourceImpl(client: client);

Future<void> main() async {
  client.authToken =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0ZTI3YTZhYjZjYmM2ZjU2ZTNhOGE2NiIsImlhdCI6MTY5Mjk0ODQ4MiwiZXhwIjoxNjk1NTQwNDgyfQ.eDMt_qZWJ8R11PFF2vikEwCgvK5-QM4n_HrixP5UgRQ';

  final article = ArticleModel(
    id: '',
    title: 'AAiT-mobile-2',
    subTitle: 'Create Article Test',
    content: 'This is a test article',
    date: DateTime.now(),
    photoUrl: r'C:\Users\L\Downloads\image.jpg',
    author: const UserData(
        id: 'id',
        fullName: 'fullName',
        email: 'email',
        expertise: 'expertise',
        bio: 'bio',
        createdAt: 'createdAt',
        image: 'image',
        imageCloudinaryPublicId: 'imageCloudinaryPublicId',
        articles: []),
    tags: const [Tag(name: 'art'), Tag(name: 'sports')],
    estimatedReadTime: '1min',
  );

  final newArticle = await repo.createArticle(article);

  final _article = ArticleModel(
    id: newArticle.id,
    title: 'AAiT-mobile-2',
    subTitle: 'Update Article Test',
    content: 'This is a test article',
    date: DateTime.now(),
    photoUrl: r'C:\Users\L\Downloads\image.jpg',
    author: const UserData(
        id: 'id',
        fullName: 'fullName',
        email: 'email',
        expertise: 'expertise',
        bio: 'bio',
        createdAt: 'createdAt',
        image: 'image',
        imageCloudinaryPublicId: 'imageCloudinaryPublicId',
        articles: []),
    tags: const [Tag(name: 'art'), Tag(name: 'sports')],
    estimatedReadTime: '1min',
  );

  final updatedArticle = await repo.updateArticle(_article);

  print(updatedArticle);
}
