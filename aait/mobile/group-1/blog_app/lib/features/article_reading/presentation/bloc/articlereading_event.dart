part of 'articlereading_bloc.dart';

abstract class ArticlereadingEvent extends Equatable {
  const ArticlereadingEvent();

  @override
  List<Object> get props => [];
}

class GetAuthorEvent extends ArticlereadingBloc {
  final String authorId;

  GetAuthorEvent({required this.authorId});
}
