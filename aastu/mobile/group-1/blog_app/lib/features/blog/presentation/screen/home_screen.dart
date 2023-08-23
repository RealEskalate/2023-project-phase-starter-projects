import 'package:blog_app/features/blog/presentation/widgets/home_app_bar.dart';
import 'package:flutter/material.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});
  @override
  HomeScreenState createState() => HomeScreenState();
}

class HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: getHomeAppBar(),
        body: const Center(
          child: Text("Home Screen Page"),
        ));
  }
}
