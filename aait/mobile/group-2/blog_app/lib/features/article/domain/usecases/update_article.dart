import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class UpdateArticle extends UseCase<Article, UpdateParams> {
  final ArticleRepository _articleRepository;

  UpdateArticle(this._articleRepository);

  @override
  Future<Either<Failure, Article>> call(UpdateParams params) async {
    return await _articleRepository.updateArticle(params.article);
  }
}

class UpdateParams extends Equatable {
  final Article article;

  const UpdateParams({required this.article});

  @override
  List<Object?> get props => [article];
}
