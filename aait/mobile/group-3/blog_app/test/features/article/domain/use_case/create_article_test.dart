import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/create_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late CreateArticleUsecase usecase;
  late ArticleRepository repository;

  setUp(() {
    repository = MockArticleRepository();
    usecase = CreateArticleUsecase(repository);
  });

  test("should call the [ArticleRepository.createArticle]", () async {
    // Arrange
    final article = Article.empty();
    final params = CreateArticleParams.empty();
    when(
      () => repository.createArticle(
        tags: any(named: 'tags'),
        content: any(named: 'content'),
        title: any(named: 'title'),
        subTitle: any(named: 'subTitle'),
        estimatedReadTime: any(named: 'estimatedReadTime'),
        image: any(named: 'image'),
      ),
    ).thenAnswer((_) async => Right(article));
    // Act
    final result = await usecase(params);

    // Assert
    expect(result, Right<dynamic, Article>(article));
    verify(()=> repository.createArticle(
        tags: any(named: 'tags'),
        content: any(named: 'content'),
        title: any(named: 'title'),
        subTitle: any(named: 'subTitle'),
        estimatedReadTime: any(named: 'estimatedReadTime'),
        image: any(named: 'image'),
      ),).called(1);
    verifyNoMoreInteractions(repository);
  });
}
