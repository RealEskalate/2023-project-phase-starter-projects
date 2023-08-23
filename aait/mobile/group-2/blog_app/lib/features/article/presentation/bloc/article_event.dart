import 'package:equatable/equatable.dart';

import '../../domain/entities/article.dart';

sealed class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object?> get props => [];
}

final class CreateArticleEvent extends ArticleEvent {
  final Article article;

  const CreateArticleEvent(this.article);

  @override
  List<Object?> get props => [article];
}

final class UpdateArticleEvent extends ArticleEvent {
  final Article article;

  const UpdateArticleEvent(this.article);

  @override
  List<Object?> get props => [article];
}
