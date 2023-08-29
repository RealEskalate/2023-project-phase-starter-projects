import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class AddToBookmark extends UseCase<Article, AddToBookmarkParams> {
  final ArticleRepository _articleRepository;

  AddToBookmark(this._articleRepository);

  @override
  Future<Either<Failure, Article>> call(AddToBookmarkParams params) async {
    return await _articleRepository.addToBookmark(params.article);
  }
}

class AddToBookmarkParams extends Equatable {
  final Article article;

  const AddToBookmarkParams({required this.article});

  @override
  List<Object?> get props => [article];
}
