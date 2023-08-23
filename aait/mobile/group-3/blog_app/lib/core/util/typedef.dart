import 'package:dartz/dartz.dart';

import '../error/failure.dart';

typedef ResultFuture<T> = Future<Either<Failure, T>>;
