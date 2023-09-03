part of 'articlereading_bloc.dart';

abstract class ArticlereadingState extends Equatable {
  const ArticlereadingState();

  @override
  List<Object> get props => [];
}

class ArticlereadingInitial extends ArticlereadingState {}

class ArticlereadingLoading extends ArticlereadingState {}

class ArticlereadingError extends ArticlereadingState {
  final String message;
  ArticlereadingError({this.message = "Something went wrong!"});
}
