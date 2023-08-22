
import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:formz/formz.dart';
import 'create_task_formfields.dart';
part 'create_task_state.dart';

class CreateTaskCubit extends Cubit<CreateTaskState> {
  CreateTaskCubit() : super(CreateTaskState(tags: []));

  void titleChanged(String value) {
    final title = TitleInput.dirty(value);
    emit(state.copyWith(
      title: title,
    ));
  }

  void subtitleChanged(String value) {
    final subtitle = SubtitleInput.dirty(value);
    emit(state.copyWith(
      subtitle: subtitle,
    ));
  }

  void contentChanged(String value) {
    final content = ContentInput.dirty(value);
    emit(state.copyWith(
      content: content,
    ));
  }

  void tagChanged(String value) {
    final tag = TagInput.dirty(value);
    emit(state.copyWith(
      tag: tag,
    ));
  }

  void removeTag(int index) {
    final tags = state.tags;
    tags.removeAt(index);
    emit(state.copyWith(
      tags: tags,
      changeIndicator: state.changeIndicator + 1,
    ));
  }

  void addTag() {
    final tag = TagInput.dirty(state.tag.value);
    final index = state.tags.indexOf(tag.value);
    if (tag.isValid && index == -1) {
      final tags = state.tags;
      tags.add(tag.value);
      emit(state.copyWith(
        tags: tags,
        tag: const TagInput.pure(),
      ));
    }
  }
    void publish(){
      final title = TitleInput.dirty(state.title.value);
      final subtitle = SubtitleInput.dirty(state.subtitle.value);
      final content = ContentInput.dirty(state.content.value);
      final tags = state.tags;
      final tag = TagInput.dirty(state.tag.value);
      if(title.isValid && subtitle.isValid && content.isValid && tags.isNotEmpty && tag.isValid) {
        emit(state.copyWith(
          status: FormzSubmissionStatus.inProgress,
        ));
        // wait for 5 seconds
        Future.delayed(const Duration(seconds: 5), () {
          emit(state.copyWith(
            status: FormzSubmissionStatus.success,
          ));
        });
      }  else {
        emit(state.copyWith(
          status: FormzSubmissionStatus.failure,
        ));
      }

    }
  }

