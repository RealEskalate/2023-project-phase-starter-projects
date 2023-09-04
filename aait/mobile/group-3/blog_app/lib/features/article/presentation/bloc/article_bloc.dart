import 'dart:async';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../domain/entity/getArticlesEntity.dart';
import '../../domain/use_case/get_tags.dart';
import '../../../../core/use_case/usecase.dart';
import '../../domain/use_case/delete_article.dart';
import '../../domain/use_case/get_all_articles.dart';
import '../../domain/entity/article.dart';
import '../../domain/use_case/get_article_by_id.dart';

part 'article_event.dart';
part 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  ArticleBloc({
    required GetArticleByIdUsecase getArticleById,
    required GetAllArticlesUsecase getAllArticles,
    required DeleteArticleUsecase deleteArticle,
    required GetTagsUsecase getTags,
  })  : _getArticleById = getArticleById,
        _getAllArticles = getAllArticles,
        _deleteArticle = deleteArticle,
        _getTags = getTags,
        super(const ArticleInitial()) {
    on<GetArticleByIdEvent>(_getArticleByIdHandler);
    on<GetAllArticlesEvent>(_getAllArticlesHandler);
    on<DeleteArticleEvent>(_deleteArticleHandler);
    on<GetTagsEvent>(_getTagsHandler);
  }

  final GetArticleByIdUsecase _getArticleById;
  final GetAllArticlesUsecase _getAllArticles;
  final DeleteArticleUsecase _deleteArticle;
  final GetTagsUsecase _getTags;

  FutureOr<void> _getArticleByIdHandler(
      GetArticleByIdEvent event, Emitter<ArticleState> emit) async {
    emit(const GettingArticle());
    final result = await _getArticleById(event.id);

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (article) => emit(ArticleLoaded(article)));
  }

  FutureOr<void> _getAllArticlesHandler(
      GetAllArticlesEvent event, Emitter<ArticleState> emit) async {
    emit(const GettingArticles());

    final result = await _getAllArticles(ArticleRequest(
      queryString: event.searchQuery,
      tags: event.tags,
    ));

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (articles) => emit(ArticlesLoaded(articles)));
  }

  FutureOr<void> _deleteArticleHandler(
      DeleteArticleEvent event, Emitter<ArticleState> emit) async {
    emit(DeletingArticle());
    final result = await _deleteArticle(event.id);

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (_) => emit(ArticleDeleted()));
  }

  FutureOr<void> _getTagsHandler(
      GetTagsEvent event, Emitter<ArticleState> emit) async {
    emit(const GettingArticle());
    final result = await _getTags(NoParams());
    result.fold((failure) => emit(TagsError(failure.errorMessage)),
        (tags) => emit(TagsLoaded(tags)));
  }
}
