import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/cupertino.dart';
import 'package:image_picker/image_picker.dart';

import '../../../../core/use_case/usecase.dart';
import '../../domain/use_case/get_article_by_id.dart';
import '../../domain/use_case/get_tags.dart';
import '../../domain/use_case/update_article.dart';
import '../../../../core/util/estimate_read_time_calculator.dart';
import '../../domain/entity/article.dart';

part 'update_article_event.dart';
part 'update_article_state.dart';

class UpdateArticleBloc extends Bloc<UpdateArticleEvent, UpdateArticleState> {
  final UpdateArticleUsecase updateArticleUsecase;
  final GetArticleByIdUsecase getArticleByIdUsecase;
  final GetTagsUsecase getTagsUsecase;

  UpdateArticleBloc(
      {required this.updateArticleUsecase,
      required this.getArticleByIdUsecase,
      required this.getTagsUsecase})
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
        estimatedReadTime: calculateEstimatedReadTime(event.content),
        image: event.postImage,
        id: event.id));

    updateArticle.fold(
        (failure) => emit(UpdateArticleError(message: failure.errorMessage)),
        (article) => emit(UpdateArticleResult(article: article)));
  }

  _resetUpdateControllers(ResetUpdateField event, emit) async {
    emit(UpdateArticleLoading());
    final article = await getArticleByIdUsecase(event.id);
    final tags = await getTagsUsecase(NoParams());
    article.fold(
      (l) => emit(UpdateArticleError(message: l.errorMessage)),
      (article) => tags.fold(
        (l) => emit(UpdateArticleError(message: l.errorMessage)),
        (tags) => emit(
          UpdateArticleLoaded(
            articleId: article.id,
            content: TextEditingController(text: article.content),
            title: TextEditingController(text: article.title),
            subTitle: TextEditingController(text: article.subTitle),
            photoImage: article.image,
            selectedTags: article.tags,
            availableTags: tags,
          ),
        ),
      ),
    );
  }

  _fetchData(GetArticleData event, emit) async {
    emit(UpdateArticleLoading());
    final articleFuture = await getArticleByIdUsecase(event.id);
    final tagsFuture = await getTagsUsecase(NoParams());
    articleFuture.fold(
      (l) => emit(UpdateArticleError(message: l.errorMessage)),
      (article) => tagsFuture.fold(
        (l) => emit(UpdateArticleError(message: l.errorMessage)),
        (tags) => emit(
          UpdateArticleLoaded(
            articleId: article.id,
            content: TextEditingController(text: article.content),
            title: TextEditingController(text: article.title),
            subTitle: TextEditingController(text: article.subTitle),
            photoImage: article.image,
            selectedTags: article.tags,
            availableTags: tags,
          ),
        ),
      ),
    );
  }
}

//   FutureOr<void> _fetchAllTags(GetAvailableTags event, Emitter<UpdateArticleState> emit) async {
//     emit(GetTagsLoading());
//     final tags = await getTagsUsecase(NoParams());

//     tags.fold((l) => emit(UpdateArticleError(message: l.errorMessage)), (tags) => emit(UpdateArticleLoaded(articleId: articleId, content: content, title: title, subTitle: subTitle, photoImage: photoImage, availableTags: availableTags, selectedTags: selectedTags)))

//   }
// }
