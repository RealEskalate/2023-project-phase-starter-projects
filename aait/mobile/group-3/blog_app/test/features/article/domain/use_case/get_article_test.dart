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
    final article = [Article.empty()];
    when(() => repository.getArticle(tags: any(named: 'tags'), searchParams: any(named: 'searchParams'))).thenAnswer((_) async => Right(article));
    // Act
    final result = await usecase(GetArticleParams.empty());
    // Assert
    expect(result, equals(Right<dynamic, List<Article>>(article)));
    verify(() => repository.getArticle(tags: 'Other', searchParams: 'searchParams')).called(1);
    verifyNoMoreInteractions(repository);
  });

}