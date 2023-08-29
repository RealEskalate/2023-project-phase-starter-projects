import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/usecase/usecase.dart';
import '../../domain/usecases/usecases.dart';
import 'bookmark_event.dart';
import 'bookmark_state.dart';

export 'bookmark_event.dart';
export 'bookmark_state.dart';

class BookmarkBloc extends Bloc<BookmarkEvent, BookmarkState> {
  final AddToBookmark addToBookmark;
  final RemoveFromBookmark removeFromBookmark;
  final LoadBookmarks loadBookmarks;

  BookmarkBloc({
    required this.addToBookmark,
    required this.removeFromBookmark,
    required this.loadBookmarks,
  }) : super(BookmarkInitialState()) {
    //
    //
    on<LoadBookmarksEvent>(_loadBookmarks);
    on<AddToBookmarkEvent>(_addToBookmark);
    on<RemoveFromBookmarkEvent>(_removeFromBookmark);
  }

  Future<void> _loadBookmarks(
      LoadBookmarksEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result = await loadBookmarks(NoParams());

    result.fold(
      (failure) => emit(BookmarkErrorState(failure.toString())),
      (articles) => emit(BookmarkLoadedState(articles)),
    );
  }

  Future<void> _addToBookmark(
      AddToBookmarkEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result =
        await addToBookmark(AddToBookmarkParams(article: event.article));

    result.fold(
      (failure) => emit(BookmarkErrorState(failure.toString())),
      (article) => emit(BookmarkAddedState(article)),
    );
  }

  Future<void> _removeFromBookmark(
      RemoveFromBookmarkEvent event, Emitter<BookmarkState> emit) async {
    emit(BookmarkLoadingState());

    final result =
        await removeFromBookmark(RemoveFromBookmarkParams(id: event.id));

    result.fold(
      (failure) => emit(BookmarkErrorState(failure.toString())),
      (article) => emit(BookmarkRemovedState(article)),
    );
  }
}
