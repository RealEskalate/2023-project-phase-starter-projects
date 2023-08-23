import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:blog_app/features/profile/domain/use_case/get_all_articles.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_all_articles_test.mocks.dart';

@GenerateNiceMocks([MockSpec<ProfileRepository>()])
void main() {
  late MockProfileRepository mockProfileRepository;
  late GetAllArticles usecase;

  setUp(() {
    mockProfileRepository = MockProfileRepository();
    usecase = GetAllArticles(mockProfileRepository);
  });

  group("GetAllArticles", () {
    final List<Article> tEmptyArticle = [];
    test(
        'Should be able to call getAllTasks from repository when usecase is called',
        () async {
      when(mockProfileRepository.getAllArticles())
          .thenAnswer((_) async => Right(<Article>[]));
      await usecase(NoParams());
      verify(mockProfileRepository.getAllArticles());
      verifyNoMoreInteractions(mockProfileRepository);
    });

    test('Should return a valid List<Articles> when a successful call was made',
        () async {
      when(mockProfileRepository.getAllArticles())
          .thenAnswer((_) async => Right(tEmptyArticle));
      final result = await usecase(NoParams());
      expect(result, Right(tEmptyArticle)); 
    });
  });
}
