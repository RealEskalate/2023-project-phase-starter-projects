import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/get_all_articles.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late GetAllArticlesUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = GetAllArticlesUsecase(repository);
  });
  
  final params = NoParams();
  test("should call [AricleRepository.getAllArticles]",
     () async {
    // Arrange
    final articles = [Article.empty()];
    when(() => repository.getAllArticles()).thenAnswer((_) async => Right(articles));
    // Act
    final result = await usecase(params);
    // Assert
    expect(result,equals(Right<dynamic, List<Article>>(articles)));
    verify(() => repository.getAllArticles()).called(1);
    verifyNoMoreInteractions(repository);
  });
 
}