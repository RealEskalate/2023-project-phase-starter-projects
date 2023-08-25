
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/delete_article.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late DeleteArticleUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = DeleteArticleUsecase(repository);
  });
  const id = "1";
  test("should call [ArticleRepository.deleteArticle]",
     () async {
    // Arrange
    when(()=> repository.deleteArticle(any())).thenAnswer((_) async => const Right(true));
    // Act
    final result = await usecase(id);
    // Assert
    expect(result, const Right<dynamic, bool>(true));
    verify(() => repository.deleteArticle(id)).called(1);
    verifyNoMoreInteractions(repository);
  });
}