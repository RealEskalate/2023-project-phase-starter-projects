import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/use_case/usecase.dart';
import '../../../../core/util/estimate_read_time_calculator.dart';
import '../../domain/entity/article.dart';
import '../../domain/use_case/create_article.dart';
import '../../domain/use_case/get_tags.dart';

part 'create_article_event.dart';
part 'create_article_state.dart';

class CreateArticleBloc extends Bloc<CreateArticleEvent, CreateArticleState> {
  final CreateArticleUsecase createArticleUsecase;
  final GetTagsUsecase getTagsUsecase;
  CreateArticleBloc(this.createArticleUsecase, this.getTagsUsecase)
      : super(CreateArticleInitial()) {
    on<SendData>(_sendToCreateArticle);
    on<ResetCreate>(_resetControllers);
    on<GetAllTags>(_featchTags);
  }
  _sendToCreateArticle(SendData event, emit) async {
    emit(CreateArticleLoading());
    final createdArticle = await createArticleUsecase(CreateArticleParams(
      tags: event.tags,
      content: event.content,
      title: event.title,
      subTitle: event.subTitle,
      estimatedReadTime: calculateEstimatedReadTime(event.content),
      image: event.postImage,
    ));

    createdArticle.fold(
      (failure) => emit(CreateArticleError(errorMessage: failure.errorMessage)),
      (article) => emit(CreateArticleResult(article: article)),
    );
  }

  _featchTags(GetAllTags event, emit) async {
    emit(GetAllTagsLoading());

    final tags = await getTagsUsecase(NoParams());

    tags.fold(
        (failure) =>
            emit(CreateArticleError(errorMessage: failure.errorMessage)),
        (tags) => emit(AllTagsLoaded(
              tags: tags,
              content: TextEditingController(),
              title: TextEditingController(),
              subTitle: TextEditingController(),
              photoImage: "",
            )));
  }

  _resetControllers(event, emit) async {
    emit(GetAllTagsLoading());
    final tags = await getTagsUsecase(NoParams());
    tags.fold(
        (l) => emit(CreateArticleError(errorMessage: l.errorMessage)),
        (tags) => emit(
              AllTagsLoaded(
                selectedTags: [],
                tags: tags,
                content: TextEditingController(),
                title: TextEditingController(),
                subTitle: TextEditingController(),
                photoImage: "",
              ),
            ));
  }
}
