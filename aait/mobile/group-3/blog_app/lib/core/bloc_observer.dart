import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AppBlocObserver extends BlocObserver {
  @override
  void onCreate(BlocBase bloc) {
    super.onCreate(bloc);
    debugPrint('onCreate --  ${bloc.runtimeType}');
  }

  @override
  void onEvent(Bloc bloc, Object? event) {
    super.onEvent(bloc, event);
    debugPrint('onCreate --  ${bloc.runtimeType}, $event');

  }

  @override
  void onError(BlocBase bloc, Object error, StackTrace stackTrace) {
    super.onError(bloc, error, stackTrace);
    debugPrint('onCreate --  ${bloc.runtimeType} $error');

  }

  @override
  void onTransition(Bloc bloc, Transition transition) {
    super.onTransition(bloc, transition);
    debugPrint('onCreate --  ${bloc.runtimeType} $transition');

  }

  @override
  void onChange(BlocBase bloc, Change change) {
    super.onChange(bloc, change);
    debugPrint('onCreate --  ${bloc.runtimeType} $change');
    
  }

  @override
  void onClose(BlocBase bloc) {
    super.onClose(bloc);
    debugPrint('onCreate --  ${bloc.runtimeType}');

  }
}
