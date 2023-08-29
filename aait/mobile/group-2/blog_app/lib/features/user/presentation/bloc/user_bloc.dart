import 'dart:async';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';
import '../../../article/data/models/article_model.dart';
import '../../../article/domain/entities/article.dart';
import '../../domain/entities/user_data.dart';
import '../../domain/usecases/user_usecases/add_bookmart_usecase.dart';
import '../../domain/usecases/user_usecases/get_bookmarked_articles_usecase.dart';
import '../../domain/usecases/user_usecases/get_user_data_usecase.dart';
import '../../domain/usecases/user_usecases/update_user_photo_usecase.dart';

part 'user_event.dart';
part 'user_state.dart';

const String SERVER_FAILURE_MESSAGE = 'Server Failure';
const String CACHE_FAILURE_MESSAGE = 'Cache Failure';
const String NETWORK_FAILURE_MESSAGE = 'Network Failure';

class UserBloc extends Bloc<UserEvent, UserState> {
  final GetUserData getUser;
  final UpdateUserPhoto updateUserPhoto;
  final GetBookmarkedArticles getBookmarkedArticles;
  final AddBookmark addBookmark;

  UserBloc(
      {required this.addBookmark,
      required this.getUser,
      required this.updateUserPhoto,
      required this.getBookmarkedArticles})
      : super(UserInitial()) {
    on<GetUserEvent>(_onGetUserData);
    on<UpdateUserPhotoEvent>(_onUpdateUserPhoto);
    on<GetBookmarkedArticlesEvent>(_onGetBookmarkedArticles);
    on<BookmarkButtonClickedEvent>(_onBookmarkButtonClicked);
  }

  String _mapFailureToMessage(Failure failure) {
    switch (failure.runtimeType) {
      case ServerFailure:
        return SERVER_FAILURE_MESSAGE;
      case CacheFailure:
        return CACHE_FAILURE_MESSAGE;
      case NetworkFailure:
        return NETWORK_FAILURE_MESSAGE;
      default:
        return 'Unexpected error';
    }
  }

  FutureOr<void> _onGetUserData(
      GetUserEvent event, Emitter<UserState> emit) async {
    emit(LoadingState());

    final userOrError = await getUser(GetUserDataParams(token: event.token));

    userOrError.fold(
      (failure) => emit(
        ErrorState(
          message: _mapFailureToMessage(failure),
        ),
      ),
      (user) => emit(
        LoadedUserState(userData: user),
      ),
    );
  }

  FutureOr<void> _onUpdateUserPhoto(
      UpdateUserPhotoEvent event, Emitter<UserState> emit) async {
    emit(LoadingState());
    final userOrError = await updateUserPhoto(
      UpdateUserPhotoParams(token: event.token, imagePath: event.imagePath),
    );

    userOrError.fold(
      (failure) => emit(
        ErrorState(
          message: _mapFailureToMessage(failure),
        ),
      ),
      (user) => emit(
        UserProfileUpdatedState(),
      ),
    );
  }

  FutureOr<void> _onGetBookmarkedArticles(
      GetBookmarkedArticlesEvent event, Emitter<UserState> emit) async {
    emit(LoadingState());
    final bookmarkedArticlesOrError = await getBookmarkedArticles(NoParams());

    bookmarkedArticlesOrError.fold(
      (failure) => emit(
        ErrorState(
          message: _mapFailureToMessage(failure),
        ),
      ),
      (articles) => emit(
        LoadedBookmarkedArticlesState(articles: articles),
      ),
    );
  }

  Future<FutureOr<void>> _onBookmarkButtonClicked(
      BookmarkButtonClickedEvent event, Emitter<UserState> emit) async {
    final articleOrError =
        await addBookmark(GetArticleParams(article: event.article));

    articleOrError.fold(
        (failure) => emit(
              ErrorState(
                message: _mapFailureToMessage(failure),
              ),
            ),
        (article) => emit(
              BookmarkButtonClickedState(),
            ));
  }
}
