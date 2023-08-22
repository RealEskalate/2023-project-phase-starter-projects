import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class CreateArticle extends UseCase<Article, CreateParams> {
  final ArticleRepository _articleRepository;

  CreateArticle(this._articleRepository);

  @override
  Future<Either<Failure, Article>> call(CreateParams params) async {
    return await _articleRepository.createArticle(params.article);
  }
}

class CreateParams extends Equatable {
  final Article article;

  const CreateParams({required this.article});

  @override
  List<Object?> get props => [article];
}
