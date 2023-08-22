import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class DeleteArticle implements UseCase<Article, DeleteParams> {
  final ArticleRepository repository;

  const DeleteArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(DeleteParams params) async {
    return await repository.deleteArticle(params.id);
  }
}

class DeleteParams extends Equatable {
  final String id;

  const DeleteParams({required this.id});

  @override
  List<Object?> get props => [id];
}
