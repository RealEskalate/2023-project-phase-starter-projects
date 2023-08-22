import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';

import '../../../../core/usecase/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticle implements UseCase<Article, GetParams> {
  final ArticleRepository repository;

  GetArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(GetParams params) async {
    return await repository.getArticle(params.id);
  }

}

class GetParams extends Equatable{
  final String id;

  const GetParams({required this.id});
  
  @override
  List<Object?> get props => [id];
}