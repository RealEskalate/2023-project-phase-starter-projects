import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

import '../entities/article.dart';
import '../entities/tag.dart';
import '../repositories/article_repository.dart';

class FilterArticles implements UseCase<List<Article>, FilterParams> {
  final ArticleRepository repository;

  FilterArticles(this.repository);

  @override
  Future<Either<Failure, List<Article>>> call(FilterParams params) async {
    return await repository.filterArticles(params.tag, params.title);
  }
}

class FilterParams extends Equatable {
  final Tag tag;
  final String title;

  const FilterParams({required this.tag, required this.title});

  @override
  List<Object?> get props => [tag, title];
}
