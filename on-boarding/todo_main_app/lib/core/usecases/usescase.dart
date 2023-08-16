import 'dart:async';

import 'package:todo_main_app/features/todo/domain/entities/todo.dart';

abstract class UseCase<Output, Input> {
  Future<Output> call(Input input);
}

class NoParams {}
