import 'package:bloc_test/bloc_test.dart';
import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/use_case/create_article.dart';
import 'package:blog_app/features/article/domain/use_case/get_article_by_id.dart';
import 'package:blog_app/features/article/domain/use_case/update_article.dart';
import 'package:blog_app/features/article/presentation/bloc/article_bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mocktail/mocktail.dart';

class MockCreateArticle extends Mock implements CreateArticleUsecase {}

class MockUpdateArticle extends Mock implements UpdateArticleUsecase {}

class MockGetArticleById extends Mock implements GetArticleByIdUsecase {}

void main() {
  late CreateArticleUsecase createArticle;
  late UpdateArticleUsecase updateArticle;
  late GetArticleByIdUsecase getArticleById;
  late ArticleBloc bloc;

  final tCreateArticlePrams = CreateArticleParams.empty();
  final tServerFailure = ServerFailure(message: 'message', statusCode: 400);

  setUp(() {
    createArticle = MockCreateArticle();
    updateArticle = MockUpdateArticle();
    getArticleById = MockGetArticleById();
    bloc = ArticleBloc(
      createArticle: createArticle,
      updateArticle: updateArticle,
      getArticleById: getArticleById,
    );
    registerFallbackValue(const CreateArticleParams(
      tags: ['tags'],
      content: 'content',
      title: 'title',
      subTitle: 'subTitle',
      estimatedReadTime: 'estimatedReadTime',
      image: 'image',
    ));
  });

  tearDown(() => bloc.close());

  test('initial state should be [ArticleInitial]', () async {
    expect(bloc.state, const ArticleInitial());
  });

  group('createArticle', () {
    blocTest<ArticleBloc, ArticleState>(
      'emits [CreatingArticle, ArticleCreated] when CreateArticleEvent is added.',
      build: () {
        when(() => createArticle(any()))
            .thenAnswer((_) async => Right(Article.empty()));
        return bloc;
      },
      act: (bloc) => bloc.add(const CreateArticleEvent(
        tags: ['_empty.tags'],
        content: '_empty.content',
        title: '_empty.title',
        subTitle: '_empty.subTitle',
        estimatedReadTime: '_empty.estimatedReadTime',
        image: '_empty.image',
      )),
      expect: () => <ArticleState>[
        const CreatingArticle(),
        ArticleCreated(Article.empty()),
      ],
      verify: (_) {
        verify(() => createArticle(tCreateArticlePrams)).called(1);
        verifyNoMoreInteractions(createArticle);
      },
    );

    blocTest<ArticleBloc, ArticleState>(
      'emits [CreatingArticle, ArticleErro] when unsuccessful.',
      build: () {
        when(() => createArticle((any())))
            .thenAnswer((_) async => Left(tServerFailure));
        return bloc;
      },
      act: (bloc) => bloc.add(const CreateArticleEvent(
        tags: ['_empty.tags'],
        content: '_empty.content',
        title: '_empty.title',
        subTitle: '_empty.subTitle',
        estimatedReadTime: '_empty.estimatedReadTime',
        image: '_empty.image',
      )),
      expect: () => <ArticleState>[
        const CreatingArticle(),
        ArticleError(tServerFailure.errorMessage),
      ],
      verify: (_) {
        verify(() => createArticle(tCreateArticlePrams)).called(1);
        verifyNoMoreInteractions(createArticle);
      },
    );
  });
}
