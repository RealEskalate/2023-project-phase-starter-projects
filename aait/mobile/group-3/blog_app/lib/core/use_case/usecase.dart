import '../util/typedef.dart';

abstract class UseCase<Type, Params> {
  ResultFuture<Type> call (Params params);
}

class Params<T> {
  final T data;
  Params(this.data);
}

class NoParams {}