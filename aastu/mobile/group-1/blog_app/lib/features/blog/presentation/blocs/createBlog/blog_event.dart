import 'package:blog_app/features/blog/presentation/blocs/bloc_event.dart';

class CreateBlogEvent extends BlogEvent {
  final String title;
  final String subTitle;
  final List<String?> tags;
  final String content;

  const CreateBlogEvent({
    required this.title,
    required this.subTitle,
    required this.tags,
    required this.content,
  });

  @override
  List<Object> get props => [];
}
