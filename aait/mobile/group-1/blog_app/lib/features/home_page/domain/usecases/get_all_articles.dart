import 'package:blog_app/core/errors/failures/failure.dart';
import 'package:blog_app/features/authentication_and_authorization/domain/usecases/user_use_case.dart';
import 'package:blog_app/features/home_page/domain/repository/article_repository.dart';
import 'package:blog_app/features/user_profile/domain/usecases/update_user_info.dart';
import 'package:dartz/dartz.dart';


import '../entities/article.dart';

class GetAllArticles implements UseCase<List<Article>, NoParams> {
  final ArticleRepository repository;

  GetAllArticles(this.repository);

  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getAllArticles();
  }

}

