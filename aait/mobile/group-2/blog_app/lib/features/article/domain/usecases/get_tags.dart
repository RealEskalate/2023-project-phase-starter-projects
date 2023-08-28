import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../../../../core/usecase/usecase.dart';

import '../entities/tag.dart';
import '../repositories/article_repository.dart';

class GetTags implements UseCase<List<Tag>, NoParams> {
  final ArticleRepository repository;

  GetTags(this.repository);

  @override
  Future<Either<Failure, List<Tag>>> call(NoParams params) async {
    return await repository.getTags();
  }
}
