import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/usecase/usecase.dart';
import '../../domain/usecases/usecases.dart';
import 'tag_event.dart';
import 'tag_state.dart';

export 'tag_event.dart';
export 'tag_state.dart';

class TagBloc extends Bloc<TagEvent, TagState> {
  final GetTags getTags;

  TagBloc({
    required this.getTags,
  }) : super(TagInitialState()) {
    on<LoadAllTagsEvent>(_getTags);
  }

  Future<void> _getTags(
      LoadAllTagsEvent event, Emitter<TagState> emit) async {
    final result = await getTags(NoParams());

    result.fold(
      (failure) => emit(TagErrorState(failure.toString())),
      (tags) => emit(AllTagsLoadedState(tags)),
    );
  }
}
