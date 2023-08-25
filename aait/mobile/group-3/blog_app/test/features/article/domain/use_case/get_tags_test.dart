import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/article/domain/repository/article_repository.dart';
import 'package:blog_app/features/article/domain/use_case/get_tags.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

import 'article_repository.mock.dart';

void main() {
  late ArticleRepository repository;
  late GetTagsUsecase usecase;

  setUp(() {
    repository = MockArticleRepository();
    usecase = GetTagsUsecase(repository);
  });

  test("should call [ArticleRepository.getTags]",
     () async {
    // Arrange
    final tags = ['_empty.tags'];
    final params = NoParams();
    when(() => repository.getTags()).thenAnswer((_) async => Right(tags));
    // Act
    final result = await usecase(params);
    // Assert
    expect(result, Right<dynamic, List<String>>(tags));
    verify(() => repository.getTags()).called(1);
    verifyNoMoreInteractions(repository);
  });
}