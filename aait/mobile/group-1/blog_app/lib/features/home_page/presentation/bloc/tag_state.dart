import 'package:equatable/equatable.dart';

import '../../domain/entities/tag.dart';

 class TagState extends Equatable {
  const TagState();

  @override
  List<Object> get props => [];
}

 class TagInitialState extends TagState {}

 class TagLoadingState extends TagState {}

 class AllTagsLoadedState extends TagState {
  final List<Tag> tags;

  const AllTagsLoadedState(this.tags);

  @override
  List<Object> get props => [tags];
}

 class TagErrorState extends TagState {
  final String message;

  const TagErrorState(this.message);

  @override
  List<Object> get props => [message];
}
