import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/user_use_case.dart';
import 'package:blog_app/features/home_page/domain/repository/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';


import '../entities/article.dart';


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