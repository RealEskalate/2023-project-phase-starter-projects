part of 'article_bloc.dart';

sealed class ArticleState extends Equatable {
  const ArticleState();
  
  @override
  List<Object> get props => [];
}

class ArticleInitial extends ArticleState {
  const ArticleInitial();
}

class CreatingArticle extends ArticleState {
  const CreatingArticle();
}

class GettingArticles extends ArticleState {
  const GettingArticles();
}

class GettingArticle extends ArticleState {
  const GettingArticle();
}

class UpdatingArticle extends ArticleState {
  const UpdatingArticle();
}

class DeletingArticle extends ArticleState {
  const DeletingArticle();
}

class GettingTags extends ArticleState {
  const GettingTags();
}

class ArticleCreated extends ArticleState {
  final Article article;
  const ArticleCreated(this.article);

  @override
  List<Object> get props => [article.id];
}

class ArticleLoaded extends ArticleState {
  final Article article;
  const ArticleLoaded(this.article);

  @override
  List<Object> get props => [article.id];
}

class ArticlesLoaded extends ArticleState {
  final List<Article> articles;
  const ArticlesLoaded(this.articles);

  @override
  List<String> get props => articles.map((article) => article.id).toList();
}

class ArticleUpdated extends ArticleState {
  final Article article;
  const ArticleUpdated(this.article);

  @override
  List<Object> get props => [article.id];
}

class ArticleDeleted extends ArticleState {
  final Article article;
  const ArticleDeleted(this.article);

  @override
  List<Object> get props => [article.id];
}

class TagsLoaded extends ArticleState {
  final List<String> tags;
  const TagsLoaded(this.tags);
}

class ArticleError extends ArticleState {
  final String message;

  const ArticleError(this.message);

  @override
  List<String> get props => [message];
}

class TagsError extends ArticleState {
  final String message;
  const TagsError(this.message);

  @override
  List<String> get props => [message];
}
