import 'package:blog_application/features/blog/presentation/widgets/my_posts_container.dart';
import 'package:flutter/material.dart';

import '../widgets/profile_card.dart';
import '../widgets/profile_tab.dart';

class ProfileScreen extends StatelessWidget {
  const ProfileScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16.0),
          child: Text('Profile'),
        ),
        actions: [
          IconButton(
            icon: const Icon(Icons.more_horiz),
            onPressed: () {},
          ),
        ],
      ),
      body:
          Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Center(
                child: Container(
                  height: 370,
                  child: const Stack(
                     alignment: Alignment.topCenter,
                    children: [
                     ProfileCard(),
                      Positioned(
                          bottom: 40,
                          child: ProfileTab()),
                    ],
                  ),
              ),
              ),
              const MyPostsContainer(),
            ],
          ),
    );
  }
}