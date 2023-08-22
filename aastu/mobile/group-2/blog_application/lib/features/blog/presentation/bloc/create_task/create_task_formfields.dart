
import 'package:formz/formz.dart';

class TitleInput extends FormzInput<String, InvalidTitleError> {
  const TitleInput.pure() : super.pure('');
  const TitleInput.dirty([String value = '']) : super.dirty(value);

  @override
  InvalidTitleError? validator(String? value) {
    if(value!.isEmpty){
      return InvalidTitleError.empty;
    } else if(value!.length < 3){
      return InvalidTitleError._('Title must be at least 3 characters long');
    } else {
      return null;
    }
  }
}

class InvalidTitleError {
  const InvalidTitleError._(this.message);

  final String message;

  static const empty = InvalidTitleError._('Title cannot be empty');
}

class SubtitleInput extends FormzInput<String, InvalidSubtitleError> {
  //...
  const SubtitleInput.pure() : super.pure('');
  const SubtitleInput.dirty([String value = '']) : super.dirty(value);
  @override
  InvalidSubtitleError? validator(String? value) {
    if(value!.isEmpty){
      return InvalidSubtitleError.empty;
    } else if(value!.length < 3){
      return InvalidSubtitleError._('Subtitle must be at least 3 characters long');
    } else {
      return null;
    }
  }
}

class InvalidSubtitleError {
  const InvalidSubtitleError._(this.message);

  final String message;

  static const empty = InvalidSubtitleError._('Subtitle cannot be empty');
}


class ContentInput extends FormzInput<String, InvalidContentError> {
  const ContentInput.pure() : super.pure('');
  const ContentInput.dirty([String value = '']) : super.dirty(value);
  @override
  InvalidContentError? validator(String? value) {
    if(value!.isEmpty){
      return InvalidContentError.empty;
    } else if(value!.length < 10){
      return InvalidContentError._('Content must be at least 10 characters long');
    } else {
      return null;
    }
  }
}

class InvalidContentError {
  const InvalidContentError._(this.message);

  final String message;

  static const empty = InvalidContentError._('Content cannot be empty');
}

class TagInput extends FormzInput<String, InvalidTagError> {
  const TagInput.pure() : super.pure('');
  const TagInput.dirty([String value = '']) : super.dirty(value);
  @override
  InvalidTagError? validator(String? value) {
    return value?.length == 0
        ? InvalidTagError.empty
        : null;
  }
}

class InvalidTagError {
  const InvalidTagError._(this.message);

  final String message;

  static const empty = InvalidTagError._('Tag cannot be empty');
}