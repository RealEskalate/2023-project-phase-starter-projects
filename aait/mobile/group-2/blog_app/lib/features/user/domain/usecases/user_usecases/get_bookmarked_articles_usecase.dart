import 'package:dartz/dartz.dart';

import '../../../../../core/error/failure.dart';
import '../../../../../core/usecase/usecase.dart';
import '../../../../article/domain/entities/article.dart';
import '../../repositories/user_repository.dart';

class GetBookmarkedArticles implements UseCase<List<Article>, NoParams> {
  final UserRepository repository;

  GetBookmarkedArticles(this.repository);

  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getBookmarkedArticles();
  }
}
