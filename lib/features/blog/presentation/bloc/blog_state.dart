part of 'blog_bloc.dart';

abstract class BlogState extends Equatable {
  const BlogState();  

  @override
  List<Object> get props => [];
}
class BlogInitial extends BlogState {}
