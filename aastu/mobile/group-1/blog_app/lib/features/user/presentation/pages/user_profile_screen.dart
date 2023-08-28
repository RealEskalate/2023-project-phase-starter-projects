import 'package:flutter/material.dart';
import '../widgets/about_me.dart';
import '../widgets/my_post.dart';
import '../widgets/header.dart';

class UserProfileScreen extends StatefulWidget {
  const UserProfileScreen({super.key});

  @override
  State<UserProfileScreen> createState() => UserProfileScreenState();
}

class UserProfileScreenState extends State<UserProfileScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: const Color.fromARGB(255, 255, 255, 255),
      child: MaterialApp(
        title: 'Profile',
        home: Scaffold(
          backgroundColor: const Color.fromARGB(255, 255, 255, 255),
          appBar: header(),
          body: Column(
            children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Aboutme(),
              ),
              const Expanded(child: Myposts()),
            ],
          ),
        ),
      ),
    );
  }
}
