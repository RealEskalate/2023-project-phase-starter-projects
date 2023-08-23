import 'package:flutter_bloc/flutter_bloc.dart';

import '../../domain/usecases/usecases.dart';
import 'article_event.dart';
import 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final CreateArticle createArticle;
  final UpdateArticle updateArticle;

  ArticleBloc({
    required this.createArticle,
    required this.updateArticle,
  }) : super(ArticleInitialState()) {
    on<CreateArticleEvent>(_createArticle);
    on<UpdateArticleEvent>(_updateArticle);
  }

  Future<void> _createArticle(
      CreateArticleEvent event, Emitter<ArticleState> emit) async {
    final result = await createArticle(CreateParams(article: event.article));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleCreatedState(article)),
    );
  }

  Future<void> _updateArticle(
      UpdateArticleEvent event, Emitter<ArticleState> emit) async {
    final result = await updateArticle(UpdateParams(article: event.article));

    result.fold(
      (failure) => emit(ArticleErrorState(failure.toString())),
      (article) => emit(ArticleCreatedState(article)),
    );
  }
}
