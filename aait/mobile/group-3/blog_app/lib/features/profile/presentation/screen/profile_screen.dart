import 'package:flutter/material.dart';

import '../widgets/feed_content.dart';
import '../widgets/post_content.dart';
import '../widgets/profile_content.dart';
import '../widgets/row_button.dart';
import '../widgets/title_bar.dart';
class ProfileScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: SafeArea(
          child: Column(
            children: [
              TitleBar(),
              SizedBox(
                height: 25,
              ),
              Stack(children: [
                ProfileContent(),
                Column(children: [
                  SizedBox(
                    height: 52,
                  ),
                  Container(
                    alignment: Alignment.center,
                    child: RowButton(),
                  )
                ]),
              ]),
              SizedBox(
                height: 32,
              ),
              FeedContent(innerContent: PostContent()),
            ],
          ),
        ),
      ),
    );
  }
}

