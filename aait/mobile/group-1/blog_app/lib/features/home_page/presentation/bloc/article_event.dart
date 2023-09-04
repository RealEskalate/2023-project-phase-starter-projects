import 'package:equatable/equatable.dart';

import '../../domain/entities/tag.dart';

 class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object?> get props => [];
}

 class LoadAllArticlesEvent extends ArticleEvent {}

 class FilterArticlesEvent extends ArticleEvent {
  final Tag tag;
  final String searchParams;

  const FilterArticlesEvent(this.tag, this.searchParams);

  @override
  List<Object?> get props => [tag, searchParams];
}

 class GetSingleArticleEvent extends ArticleEvent {
  final String id;

  const GetSingleArticleEvent(this.id);

  @override
  List<Object> get props => [id];
}


