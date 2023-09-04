import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/user_use_case.dart';
import 'package:blog_app/features/home_page/domain/repository/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';



import '../entities/article.dart';
import '../entities/tag.dart';

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
