import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../../core/error/failure.dart';
import '../../../../../core/usecase/usecase.dart';
import '../../../../article/data/models/article_model.dart';
import '../../../../article/domain/entities/article.dart';
import '../../repositories/user_repository.dart';

class AddBookmark implements UseCase<Article, GetArticleParams> {
  final UserRepository repository;

  AddBookmark(this.repository);

  @override
  Future<Either<Failure, Article>> call(GetArticleParams params) async {
    return await repository.addBookmark(params.article);
  }
}

class GetArticleParams extends Equatable {
  final ArticleModel article;

  const GetArticleParams({required this.article});

  @override
  List<Object?> get props => [article];
}
