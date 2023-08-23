import 'package:dartz/dartz.dart';
import "../../../../core/exceptions/Failure.dart";
import "../repositories/auth_repository.dart";

class RegisterUseCase {
  RegisterUseCase(this.repository);
  AuthRepository repository;

  Future<Either<Failure,void>> call(String email,String password) async {
    return await repository.register(email,password);
  }
}
