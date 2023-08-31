import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

part 'articlereading_event.dart';
part 'articlereading_state.dart';

class ArticlereadingBloc
    extends Bloc<ArticlereadingEvent, ArticlereadingState> {
  ArticlereadingBloc() : super(ArticlereadingInitial()) {
    on<ArticlereadingEvent>((event, emit) {
      if (event is GetAuthorEvent) {
        emit(ArticlereadingLoading());
        // final author = await _authorRepository.getAuthor(event.authorId);
        // emit(ArticlereadingLoaded(author: author));
      }
    });
  }
}
