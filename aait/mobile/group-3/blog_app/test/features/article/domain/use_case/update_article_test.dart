import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/update_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late UpdateArticleUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = UpdateArticleUsecase(repository);
  });

  test("should call [ArticleRepository.updateArticle]", () async {
    // Arrange
    final article = Article.empty();
    final params = UpdateArticleParams.empty();
    when(() => repository.updateArticle(
          tags: any(named: 'tags'),
          content: any(named: 'content'),
          title: any(named: 'title'),
          subTitle: any(named: 'subTitle'),
          estimatedReadTime: any(named: 'estimatedReadTime'),
          image: any(named: 'image'),
        )).thenAnswer((_) async => Right(article));
    // Act
    final result = await usecase(params);
    // Assert

    expect(result, Right<dynamic, Article>(article));
    verify(() => repository.updateArticle(tags: any(named: 'tags'),
          content: any(named: 'content'),
          title: any(named: 'title'),
          subTitle: any(named: 'subTitle'),
          estimatedReadTime: any(named: 'estimatedReadTime'),
          image: any(named: 'image'),)).called(1);
    verifyNoMoreInteractions(repository);
  });
}
