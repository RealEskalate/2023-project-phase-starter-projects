import 'package:equatable/equatable.dart';

import '../../domain/entities/tag.dart';

 class TagSelectorEvent extends Equatable {
  const TagSelectorEvent();

  @override
  List<Object?> get props => [];
}

class AddTagEvent extends TagSelectorEvent {
  final Tag tag;

  const AddTagEvent(this.tag);
}

class RemoveTagEvent extends TagSelectorEvent {
  final Tag tag;

  const RemoveTagEvent(this.tag);
}
