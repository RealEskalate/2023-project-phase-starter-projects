import 'package:blog_app/core/use_case/usecase.dart';
import 'package:blog_app/features/auth/domain/repository/auth_repository.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';

class LogInUsecase extends UseCase<bool, Params>{
  final  AuthRepository repository;
  LogInUsecase(this.repository);

  @override
  Future<Either<Failure, bool>> call(Params params) async{
    return await repository.login(authEntitie: params.data);
  }
}