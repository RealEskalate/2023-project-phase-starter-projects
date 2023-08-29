import 'package:bloc/bloc.dart';
import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/article/data/models/article_model.dart';
import 'package:blog_app/features/article/domain/use_case/get_article_by_id.dart';
import 'package:blog_app/features/article/domain/use_case/update_article.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/cupertino.dart';
import 'package:image_picker/image_picker.dart';
import 'package:meta/meta.dart';

import '../../domain/entity/article.dart';

part 'update_article_event.dart';
part 'update_article_state.dart';

class UpdateArticleBloc extends Bloc<UpdateArticleEvent, UpdateArticleState> {
  final UpdateArticleUsecase updateArticleUsecase;
  final GetArticleByIdUsecase getArticleByIdUsecase;

  UpdateArticleBloc(
      {required this.updateArticleUsecase, required this.getArticleByIdUsecase})
      : super(UpdateArticleInitial()) {
    on<GetArticleData>(_fetchData);
    on<UpdateData>(_sendToUpdateArticle);
    on<ResetUpdateField>(_resetUpdateControllers);
  }

  _sendToUpdateArticle(UpdateData event, emit) async {
    emit(UpdateArticleLoading());
    final updateArticle = await updateArticleUsecase(UpdateArticleParams(
        tags: event.tags,
        content: event.content,
        title: event.title,
        subTitle: event.subTitle,
        estimatedReadTime: "10 min",
        image: event.postImage,
        id: event.id));

    updateArticle.fold(
        (failure) => emit(UpdateArticleError(message: failure.errorMessage)),
        (article) => emit(UpdateArticleResult(article: article)));
  }

  _resetUpdateControllers(ResetUpdateField event, emit) async {
    emit(UpdateArticleLoading());
    final article = await getArticleByIdUsecase(event.id);
    article.fold(
        (l) => emit(UpdateArticleError(message: l.errorMessage)),
        (article) => emit(UpdateArticleLoaded(
              articleId: article.id,
              content: TextEditingController(text: article.content),
              title: TextEditingController(text: article.title),
              subTitle: TextEditingController(text: article.subTitle),
              photoImage: TextEditingController(text: article.image),
            )));
  }

  _fetchData(GetArticleData event, emit) async {
    emit(UpdateArticleLoading());
    final article = await getArticleByIdUsecase(event.id);
    article.fold(
        (l) => UpdateArticleError(message: l.errorMessage),
        (article) => emit(UpdateArticleLoaded(
              articleId: article.id,
              content: TextEditingController(text: article.content),
              title: TextEditingController(text: article.title),
              subTitle: TextEditingController(text: article.subTitle),
              photoImage: TextEditingController(text: article.image),
            )));
  }
}
