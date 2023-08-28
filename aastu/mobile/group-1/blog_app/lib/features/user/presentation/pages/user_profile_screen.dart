import 'dart:developer';
import 'package:blog_app/features/user/presentation/blocs/bloc.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_event.dart';
import 'package:blog_app/features/user/presentation/blocs/get_user.dart/user_state.dart';
import 'package:blog_app/features/user/presentation/widgets/about_me.dart';
import 'package:blog_app/features/user/presentation/widgets/my_activities.dart';
import 'package:blog_app/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:blog_app/features/user/domain/entities/user.dart' as UserEntity;

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

  UserEntity.User user =
      UserEntity.User(fullName: '', email: '', expertise: '', bio: '');
  @override
  void initState() {
    super.initState();
    // Get User
    context.read<UserBloc>().add(const GetUserEvent());
    context.read<UserBloc>().stream.listen((state) {
      if (state is LoadedGetUserState) {
        setState(() {
          user = state.user;
        });
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return RefreshIndicator(
      onRefresh: () async {
        context.read<UserBloc>().add(const GetUserEvent());
      },
      child: Scaffold(
        backgroundColor: const Color(0xFFF8FAFF),
        appBar: AppBar(
          backgroundColor: const Color(0xFFF8FAFF),
          leading: IconButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              icon: const Icon(Icons.arrow_back_ios)),
          title: Padding(
            padding: const EdgeInsets.only(left: 32.0),
            child: Stack(
              children: [
                Text(
                  "Profile",
                  textAlign: TextAlign.left,
                  style: TextStyle(
                    foreground: Paint()
                      ..style = PaintingStyle.stroke
                      ..strokeWidth = 2
                      ..color = const Color.fromARGB(
                          255, 253, 239, 239), // Stroke color (#000000)
                    fontFamily: "Urbanist",
                    fontWeight: FontWeight.w700,
                    fontSize: 24,
                  ),
                ),
                const Text(
                  "Profile",
                  textAlign: TextAlign.left,
                  style: TextStyle(
                    color: Color.fromRGBO(
                        13, 37, 60, 1), // Fill color (#0D253C) in RGBA
                    fontFamily: "Urbanist",
                    fontWeight: FontWeight.w700,
                    fontSize: 24,
                  ),
                ),
              ],
            ),
          ),
          // leading: Placeholder(),
          actions: [
            IconButton(
              icon: const Icon(Icons.more_horiz,
                  color: Color.fromARGB(255, 0, 0, 0)),
              onPressed: () {
                // Add your three dots menu logic here
              },
            ),
          ],
          elevation: 0,
        ),
        body: Column(
          children: [
            Padding(
              padding: const EdgeInsets.fromLTRB(8, 8, 8, 0),
              child: Aboutme(
                  onActivitySelected: updateSelectedActivity, user: user),
            ),
            const SizedBox(height: 20),
            Expanded(
              child: MyActivity(activity: selectedActivity),
            ),
          ],
        ),
      ),
    );
  }
}
