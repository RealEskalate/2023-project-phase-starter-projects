import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/usecase/usecase.dart';
import '../../domain/usecases/usecases.dart';
import 'article_event.dart';
import 'article_state.dart';

export 'article_event.dart';
export 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final GetArticle getArticle;
  final GetAllArticles getAllArticles;
  final FilterArticles filterArticles;
  final CreateArticle createArticle;
  final UpdateArticle updateArticle;
  final DeleteArticle deleteArticle;

  ArticleBloc({
    required this.getArticle,
    required this.getAllArticles,
    required this.filterArticles,
    required this.createArticle,
    required this.updateArticle,
    required this.deleteArticle,
  }) : super(ArticleInitialState()) {
    on<GetSingleArticleEvent>(_getArticle);
    on<LoadAllArticlesEvent>(_getAllArticles);
    on<FilterArticlesEvent>(_filterArticles);
    on<CreateArticleEvent>(_createArticle);
    on<UpdateArticleEvent>(_updateArticle);
    on<DeleteArticleEvent>(_deleteArticle);
  }

  Future<void> _getArticle(
      GetSingleArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());

    final result = await getArticle(GetParams(id: event.id));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleCreatedState(article)),
    );
  }

  Future<void> _getAllArticles(
      LoadAllArticlesEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());

    final result = await getAllArticles(NoParams());

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (articles) => emit(AllArticlesLoadedState(articles)),
    );
  }

  Future<void> _filterArticles(
      FilterArticlesEvent event, Emitter<ArticleState> emit) async {
    final result = await filterArticles(
        FilterParams(tag: event.tag, title: event.searchParams));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (articles) => emit(AllArticlesFilteredState(articles)),
    );
  }

  Future<void> _createArticle(
      CreateArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());

    final result = await createArticle(CreateParams(article: event.article));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleCreatedState(article)),
    );
  }

  Future<void> _updateArticle(
      UpdateArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());

    final result = await updateArticle(UpdateParams(article: event.article));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleUpdatedState(article)),
    );
  }

  Future<void> _deleteArticle(
      DeleteArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());

    final result = await deleteArticle(DeleteParams(id: event.id));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleDeletedState(article)),
    );
  }
}
