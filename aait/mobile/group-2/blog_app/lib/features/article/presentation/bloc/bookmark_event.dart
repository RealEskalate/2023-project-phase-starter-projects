import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

sealed class BookmarkEvent extends Equatable {
  const BookmarkEvent();

  @override
  List<Object> get props => [];
}

final class LoadBookmarksEvent extends BookmarkEvent {}

final class AddToBookmarkEvent extends BookmarkEvent {
  final Article article;

  const AddToBookmarkEvent(this.article);

  @override
  List<Object> get props => [article];
}

final class RemoveFromBookmarkEvent extends BookmarkEvent {
  final String id;

  const RemoveFromBookmarkEvent(this.id);

  @override
  List<Object> get props => [id];
}
