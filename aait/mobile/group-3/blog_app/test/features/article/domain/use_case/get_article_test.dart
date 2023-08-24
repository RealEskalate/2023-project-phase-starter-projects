import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/get_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late GetArticleUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = GetArticleUsecase(repository);
  });

  test("should call [ArticleReository.getArticle]",
     () async {
    // Arrange
    final article = Article.empty();
    const id = "1";
    when(() => repository.getArticle(any())).thenAnswer((_) async => Right(article));
    // Act
    final result = await usecase(id);
    // Assert
    expect(result, Right<dynamic, Article>(article));
    verify(() => repository.getArticle(id)).called(1);
    verifyNoMoreInteractions(repository);
  });

}