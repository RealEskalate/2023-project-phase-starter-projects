part of 'create_task_bloc.dart';


class CreateTaskState extends Equatable {
  final TitleInput title;
  final SubtitleInput subtitle;
  final List<String> tags;
  final TagInput tag;
  final ContentInput content;
  final FormzSubmissionStatus? status;
 final int changeIndicator ;
  const CreateTaskState({
    this.title = const TitleInput.pure(),
    this.subtitle = const SubtitleInput.pure(),
    required this.tags,
    this.content = const ContentInput.pure(),
    this.tag = const TagInput.pure(),
    this.status,
    this.changeIndicator = 1
  });

  CreateTaskState copyWith({
    TitleInput? title,
    SubtitleInput? subtitle,
    List<String>? tags,
    ContentInput? content,
    FormzSubmissionStatus? status,
    TagInput? tag,
    int? changeIndicator,
  }) {
    return CreateTaskState(
      title: title ?? this.title,
      subtitle: subtitle ?? this.subtitle,
      tags: tags ?? this.tags,
      content: content ?? this.content,
      tag: tag ?? this.tag,
      changeIndicator: changeIndicator ?? this.changeIndicator,
    );
  }
  @override
  List<Object?> get props => [title, subtitle, tags.length,tag, content, changeIndicator];
}