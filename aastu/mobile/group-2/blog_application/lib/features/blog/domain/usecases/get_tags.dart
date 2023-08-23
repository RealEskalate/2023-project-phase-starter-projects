import 'package:blog_application/core/exceptions/Failure.dart';

import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/usecases/usecase.dart';
import '../repositories/article_repository.dart';

class GetTags extends UseCase<List<String> , NoParams>{
  final ArticleRepository repository;
   GetTags(this.repository);
  
  
  @override
  Future<Either<Failure, List<String>>> call(NoParams params ) async {
    return await repository.getTags();
  }

}
