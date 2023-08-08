import 'dart:async';

abstract class UseCase<Output, Input> {
  Future<Output> call(Input input);
}

class NoParams {} // An empty class to use as input for use cases that don't require parameters
