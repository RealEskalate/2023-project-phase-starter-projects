import 'package:blog_app/features/home_page/domain/usecases/get_all_articles.dart';
import 'package:blog_app/features/home_page/domain/usecases/get_article.dart';
import 'package:blog_app/features/user_profile/domain/usecases/update_user_info.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../domain/usecases/filter_articles.dart';
import 'article_event.dart';
import 'article_state.dart';

export 'article_event.dart';
export 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final GetArticle getArticle;
  final GetAllArticles getAllArticles;
  final FilterArticles filterArticles;

  ArticleBloc({
    required this.getArticle,
    required this.getAllArticles,
    required this.filterArticles,
  }) : super(ArticleLoadingState()) {
    on<GetSingleArticleEvent>(_getArticle);
    on<LoadAllArticlesEvent>(_getAllArticles);
    on<FilterArticlesEvent>(_filterArticles);
  }

  Future<void> _getArticle(
      GetSingleArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    print("here");
    final result = await getArticle(GetParams(id: event.id));
    print(result);
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
    print(result);

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (articles) => emit(AllArticlesFilteredState(articles)),
    );
  }
}
