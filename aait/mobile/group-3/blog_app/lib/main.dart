import 'package:blog_app/blog_app.dart';
import 'package:flutter/material.dart';
import 'injection_container.dart' as dependency_injection;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await dependency_injection.init();
  runApp(const BlogApp());
}
