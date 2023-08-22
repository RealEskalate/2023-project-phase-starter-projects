import '../error/failure.dart';
import 'package:dartz/dartz.dart';

typedef ResultFuture<T> = Future<Either<Failure, T>>;
