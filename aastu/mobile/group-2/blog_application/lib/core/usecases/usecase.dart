
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../exceptions/Failure.dart';

abstract class UseCase<Type , params> {
  
  Future<Either<Failure, Type>> call(params params);
}

class NoParams extends Equatable {
  @override
  List<Object?> get props => [];
}