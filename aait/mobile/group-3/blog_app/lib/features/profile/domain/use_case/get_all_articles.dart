import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/profile/domain/entity/article.dart';
import 'package:blog_app/features/profile/domain/repositories/profile_repository.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/use_case/usecase.dart';

class GetAllArticles extends UseCase<List<Article>, NoParams> {
  final ProfileRepository repository;

  GetAllArticles(this.repository);
  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getAllArticles();
  }
}
