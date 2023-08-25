import 'dart:async';
import 'package:blog_app/features/article/domain/use_case/get_tags.dart';
import 'package:image_picker/image_picker.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/use_case/usecase.dart';
import '../../domain/use_case/delete_article.dart';
import '../../domain/use_case/get_all_articles.dart';
import '../../domain/entity/article.dart';
import '../../domain/use_case/create_article.dart';
import '../../domain/use_case/get_article_by_id.dart';
import '../../domain/use_case/update_article.dart';

part 'article_event.dart';
part 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  ArticleBloc({
    required CreateArticleUsecase createArticle,
    required UpdateArticleUsecase updateArticle,
    required GetArticleByIdUsecase getArticleById,
    required GetAllArticlesUsecase getAllArticles,
    required DeleteArticleUsecase deleteArticle,
    required GetTagsUsecase getTags,
  })  : _createArticle = createArticle,
        _getArticleById = getArticleById,
        _updateArticle = updateArticle,
        _getAllArticles = getAllArticles,
        _deleteArticle = deleteArticle,
        _getTags = getTags,
        super(const ArticleInitial()) {
    on<CreateArticleEvent>(_createArticleHandler);
    on<UpdateArticleEvent>(_updateArticleHandler);
    on<GetArticleByIdEvent>(_getArticleByIdHandler);
    on<GetAllArticlesEvent>(_getAllArticlesHandler);
    on<DeleteArticleEvent>(_deleteArticleHandler);
    on<GetTagsEvent>(_getTagsHandler);
  }

  final CreateArticleUsecase _createArticle;
  final UpdateArticleUsecase _updateArticle;
  final GetArticleByIdUsecase _getArticleById;
  final GetAllArticlesUsecase _getAllArticles;
  final DeleteArticleUsecase _deleteArticle;
  final GetTagsUsecase _getTags;

  FutureOr<void> _createArticleHandler(
      CreateArticleEvent event, Emitter<ArticleState> emit) async {
    emit(const CreatingArticle());

    final result = await _createArticle(CreateArticleParams(
      tags: event.tags,
      content: event.content,
      title: event.title,
      subTitle: event.subTitle,
      estimatedReadTime: event.estimatedReadTime,
      image: event.image,
    ));

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (article) => emit(ArticleCreated(article)));
  }

  FutureOr<void> _updateArticleHandler(
      UpdateArticleEvent event, Emitter<ArticleState> emit) async {
    emit(const UpdatingArticle());

    final result = await _updateArticle(UpdateArticleParams(
      tags: event.tags,
      content: event.content,
      title: event.title,
      subTitle: event.subTitle,
      estimatedReadTime: event.estimatedReadTime,
      image: event.image,
      id: event.id,
    ));

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (article) => emit(ArticleUpdated(article)));
  }

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
    final result = await _getAllArticles(NoParams());

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (articles) => emit(ArticlesLoaded(articles)));
  }

  FutureOr<void> _deleteArticleHandler(
      DeleteArticleEvent event, Emitter<ArticleState> emit) async {
    final result = await _deleteArticle(event.id);

    result.fold((failure) => emit(ArticleError(failure.errorMessage)),
        (article) => emit(ArticleDeleted(article)));
  }

  FutureOr<void> _getTagsHandler(
      GetTagsEvent event, Emitter<ArticleState> emit) async {
    final result = await _getTags(NoParams());
    result.fold((failure) => emit(TagsError(failure.errorMessage)),
        (tags) => emit(TagsLoaded(tags)));
  }
}
