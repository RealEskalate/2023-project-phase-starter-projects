import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../widgets/feed_content.dart';
import '../widgets/post_content.dart';
import '../widgets/profile_content.dart';
import '../widgets/row_button.dart';
import '../widgets/title_bar.dart';

class ProfileScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final bloc = context.watch<ProfileBloc>();
    final state = bloc.state;

    switch (state) {
      case ProfileInitial():
        bloc.add(GetData());
        return Scaffold(
          body: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [TitleBar(), CircularProgressIndicator()],
          ),
        );
      case ProfileLoading():
        return Scaffold(
          body: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [TitleBar(), CircularProgressIndicator()],
          ),
        );
      case ProfileLoaded():
        return Scaffold(
          body: SingleChildScrollView(
            child: SafeArea(
              child: Column(
                children: [
                  TitleBar(),
                  SizedBox(
                    height: 25.h,
                  ),
                  Stack(children: [
                    ProfileContent(profile: state.profile,),
                    Column(children: [
                      SizedBox(
                        height: 52.h,
                      ),
                      Container(
                        alignment: Alignment.center,
                        child: RowButton(),
                      )
                    ]),
                  ]),
                  SizedBox(
                    height: 32.h,
                  ),
                  FeedContent(innerContent: PostContent()),
                ],
              ),
            ),
          ),
        );
      default:
        return Scaffold(
          body: Center(
            child: Text("Unimplemeted State error from ProfileScreen"),
          ),
        );
    }
  }
}
