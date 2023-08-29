import 'package:equatable/equatable.dart';

import '../../domain/entities/tag.dart';

sealed class TagState extends Equatable {
  const TagState();

  @override
  List<Object> get props => [];
}

final class TagInitialState extends TagState {}

final class TagLoadingState extends TagState {}

final class AllTagsLoadedState extends TagState {
  final List<Tag> tags;

  const AllTagsLoadedState(this.tags);

  @override
  List<Object> get props => [tags];
}

final class TagErrorState extends TagState {
  final String message;

  const TagErrorState(this.message);

  @override
  List<Object> get props => [message];
}
