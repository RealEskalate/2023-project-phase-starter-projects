import 'package:bloc/bloc.dart';
import 'package:blog_app/features/article/domain/entity/article.dart';
import 'package:blog_app/features/article/domain/use_case/create_article.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:meta/meta.dart';

part 'create_article_event.dart';
part 'create_article_state.dart';

class CreateArticleBloc extends Bloc<CreateArticleEvent, CreateArticleState> {
  final CreateArticleUsecase createArticleUsecase;
  CreateArticleBloc(this.createArticleUsecase)
      : super(CreateArticleInitial(
          content: TextEditingController(),
          title: TextEditingController(),
          subTitle: TextEditingController(),
          photoImage: TextEditingController(),
        )) {
    on<SendData>(_sendToCreateArticle);
    on<ResetCreate>(_resetControllers);
  }
  _sendToCreateArticle(SendData event, emit) async {
    emit(CreateArticleLoading());
    final createdArticle = await createArticleUsecase(CreateArticleParams(
      tags: event.tags,
      content: event.content,
      title: event.title,
      subTitle: event.subTitle,
      estimatedReadTime: "10min",
      image: event.postImage,
    ));

    createdArticle.fold(
      (failure) => emit(CreateArticleError(errorMessage: failure.errorMessage)),
      (article) => emit(CreateArticleResult(article: article)),
    );
  }

  _resetControllers(event, emit) {
    emit(CreateArticleInitial(
      content: TextEditingController(),
      title: TextEditingController(),
      subTitle: TextEditingController(),
      photoImage: TextEditingController(),
    ));
  }
}
