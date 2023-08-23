import 'package:flutter/material.dart';
import 'package:blog_application/features/blog/presentation/pages/articles_reading_screen.dart';
import "./Route.dart" as route;
import "core/routes/blog_app_routes.dart";

void main() {
  runApp(const MaterialApp(
    debugShowCheckedModeBanner: false,
    onGenerateRoute: route.controller,
    initialRoute: BlogAppRoutes.AUTH,
  ));
}
