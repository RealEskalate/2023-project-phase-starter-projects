import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class RemoveFromBookmark implements UseCase<Article, RemoveFromBookmarkParams> {
  final ArticleRepository repository;

  const RemoveFromBookmark(this.repository);

  @override
  Future<Either<Failure, Article>> call(RemoveFromBookmarkParams params) async {
    return await repository.removeFromBookmark(params.id);
  }
}

class RemoveFromBookmarkParams extends Equatable {
  final String id;

  const RemoveFromBookmarkParams({required this.id});

  @override
  List<Object?> get props => [id];
}
