import 'dart:developer';

import 'package:blog_app/core/error/failure.dart';
import 'package:blog_app/features/user/presentation/blocs/bloc_state.dart';
import 'package:dartz/dartz.dart';

import '../entities/user.dart';
import '../repositories/user_repository.dart';

class GetUserUseCase {
  final UserRepository repository;

  const GetUserUseCase(this.repository);

  Future<Either<Failure, User>> call() async {
    return await repository.getUser();
  }
}
