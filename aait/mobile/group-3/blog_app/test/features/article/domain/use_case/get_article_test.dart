import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'package:blog_app/features/article/data/models/article_model.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/get_article.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late GetArticleUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = GetArticleUsecase(repository);
  });

  test("should call [ArticleReository.getArticle]", () async {
    // Arrange
    const params = GetArticleParams.empty();
    final articles = [ArticleModel.empty()];
    when(() => repository.getArticle(
            tags: any(named: 'tags'), searchParams: any(named: 'searchParams')))
        .thenAnswer((_) async => Right(articles));
    // Act
    final result = await usecase(params);
    // Assert
    expect(result, Right<dynamic, List<Article>>(articles));
    verify(() => repository.getArticle(tags: 'Other', searchParams: 'wo'))
        .called(1);
    verifyNoMoreInteractions(repository);
  });
}
