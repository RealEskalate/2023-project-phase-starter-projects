import 'package:bloc/bloc.dart';
import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/usecases/create_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_tags.dart';
import 'package:blog_app/features/blog/presentation/blocs/create_blog/create_blod_state.dart';
import 'package:blog_app/features/blog/presentation/blocs/create_blog/create_blog_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/get_tags/get_tag_event.dart';
import 'package:blog_app/features/blog/presentation/blocs/get_tags/get_tag_state.dart';
import 'package:dartz/dartz.dart';

import 'bloc_event.dart';
import 'bloc_state.dart';

class BlogBloc extends Bloc<BlogEvent, BlogState> {
  final GetArticleUseCase getAllArticle;
  final GetSingleArticleUseCase getSingleArticle;
  final GetTagsUseCase getTags;
  final CreateArticleUseCase createArticle;

  BlogBloc(
      {required this.getAllArticle,
      required this.getSingleArticle,
      required this.getTags,
      required this.createArticle})
      : super(BlogInitial()) {
    on<GetAllArticlesEvent>((event, emit) async {
      emit(BlogLoading());

      try {
        final Either<Failure, List<Article>> result = await getAllArticle();
        emit(result.fold(
          (failure) => BlogError(_mapFailureToMessage(failure)),
          (articles) => LoadedGetBlogState(articles),
        ));
      } catch (e) {
        emit(BlogError(_mapFailureToMessage(
            const ServerFailure('Error fetching articles'))));
      }
    });

    on<GetTagsEvent>((event, emit) async {
      emit(TagLoading());

      try {
        final Either<Failure, List<String>> result = await getTags();
        emit(result.fold(
          (failure) => BlogError(_mapFailureToMessage(failure)),
          (tags) => LoadedTagsState(tags),
        ));
      } catch (e) {
        emit(BlogError(_mapFailureToMessage(
            const ServerFailure('Error fetching articles'))));
      }
    });

    on<CreateBlogEvent>((event, emit) async {
      try {
        emit(CreatingBlogState());
        print('Creating blog - STARTED');

        final Either<Failure, Article> result =
            await createArticle(CreateArticleParams(
          title: event.title,
          content: event.content,
          subTitle: event.subTitle,
          image: event.image,
          tagList: event.tags,
        ));
        print("Finished processing - in the bloc");
        // emit UserSignedInState
        emit(result.fold(
          (failure) => BlogError(_mapFailureToMessage(failure)),
          (article) => CreatedBlogState(),
        ));
      } catch (e) {
        emit(BlogError('Error creating blog'));
      }

      // print();
    });
  }
  String _mapFailureToMessage(Failure failure) {
    return 'An error occurred: $failure';
  }
}
