import 'package:blog_app/blog_app.dart';
import 'package:blog_app/core/bloc_observer.dart';
import 'package:blog_app/core/util/bookmark_preferences.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'injection_container.dart' as dependency_injection;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await dependency_injection.init();
  await BookmarkPreferences.init();
  Bloc.observer = AppBlocObserver();
  runApp(const BlogApp());
}
