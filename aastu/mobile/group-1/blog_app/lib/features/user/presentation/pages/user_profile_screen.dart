import 'package:blog_app/features/user/presentation/widgets/about_me.dart';
import 'package:blog_app/features/user/presentation/widgets/header.dart';
import 'package:blog_app/features/user/presentation/widgets/my_activities.dart';
import 'package:flutter/material.dart';

class UserProfileScreen extends StatefulWidget {
  const UserProfileScreen({super.key});

  @override
  State<UserProfileScreen> createState() => _UserProfileScreenState();
}

class _UserProfileScreenState extends State<UserProfileScreen> {
  late String selectedActivity = 'Posts';
  late int selectedIndex = 0; // Initially selected index

  void updateSelectedActivity(String newActivity) {
    setState(() {
      selectedActivity = newActivity;
    });
  }

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
                child: Aboutme(onActivitySelected: updateSelectedActivity),
              ),
              Expanded(
                child: MyActivity(activity: selectedActivity),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
