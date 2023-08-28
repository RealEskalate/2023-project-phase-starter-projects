import 'package:bloc/bloc.dart';
import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/blog/domain/entities/article.dart';
import 'package:blog_app/features/blog/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/blog/domain/usecases/get_single_article.dart';
import 'package:blog_app/features/blog/presentation/blocs/createBlog/blog_state.dart';
import 'package:dartz/dartz.dart';

import '../../domain/usecases/create_article.dart';
import 'bloc_event.dart';
import 'bloc_state.dart';
import 'createBlog/blog_event.dart';

class BlogBloc extends Bloc<BlogEvent, BlogState> {
  final GetArticleUseCase getAllArticle;
  final GetSingleArticleUseCase getSingleArticle;
  final CreateArticleUseCase createArticle;

  BlogBloc(
      {required this.getAllArticle,
      required this.getSingleArticle,
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
    on<CreateBlogEvent>((event, emit) async {
      try {
        emit(CreatingBlogState());
        print('Creating blog - STARTED');

        Map<String, Object> newArticleMap = {
          'title': event.title,
          'subTitle': event.subTitle,
          'content': event.content,
          'tags': event.tags,
          // 'image': event.image,
        };

        Article newArticle = Article(newArticleMap);

        final Either<Failure, Article> result = await createArticle(newArticle);
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
