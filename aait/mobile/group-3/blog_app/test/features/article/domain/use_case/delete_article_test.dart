
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/delete_article.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late DeleteArticleUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = DeleteArticleUsecase(repository);
  });
  final article = Article.empty();
  const id = "1";
  test("should call [ArticleRepository.deleteArticle]",
     () async {
    // Arrange
    when(()=> repository.deleteArticle(any())).thenAnswer((_) async => Right(Article.empty()));
    // Act
    final result = await usecase(id);
    // Assert
    expect(result, Right<dynamic, Article>(article));
    verify(() => repository.deleteArticle(id)).called(1);
    verifyNoMoreInteractions(repository);
  });
}