import 'package:blog_app/core/use_case/usecase.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/error/failure.dart';
import '../repository/auth_repository.dart';

class SignUpUsecase extends UseCase<bool, Params>{
  final  AuthRepository repository;
  SignUpUsecase(this.repository);
  
  @override
  Future<Either<Failure, bool>> call(Params params) async{
    return await repository.signup(authEntitie: params.data);
  }
}