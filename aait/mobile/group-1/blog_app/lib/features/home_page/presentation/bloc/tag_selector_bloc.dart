import 'package:flutter_bloc/flutter_bloc.dart';

import '../../domain/entities/tag.dart';
import 'tag_selector_event.dart';
import 'tag_selector_state.dart';

export 'tag_selector_event.dart';
export 'tag_selector_state.dart';

class TagSelectorBloc extends Bloc<TagSelectorEvent, TagSelectorState> {
  final selectedTags = <Tag>{};

  TagSelectorBloc() : super(const TagSelectorState([])) {
    on<AddTagEvent>(_addTag);
    on<RemoveTagEvent>(_removeTag);
  }

  void _addTag(AddTagEvent event, Emitter<TagSelectorState> emit) {
    selectedTags.add(event.tag);
    emit(TagSelectorState(List.from(selectedTags)));
  }

  void _removeTag(RemoveTagEvent event, Emitter<TagSelectorState> emit) {
    selectedTags.remove(event.tag);
    emit(TagSelectorState(List.from(selectedTags)));
  }
}
