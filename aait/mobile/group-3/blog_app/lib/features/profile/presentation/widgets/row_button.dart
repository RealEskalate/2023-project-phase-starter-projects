import 'package:blog_app/core/color/colors.dart';
import 'package:blog_app/features/profile/presentation/bloc/profile_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import 'button_container.dart';

class RowButton extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final bloc = context.watch<ProfileBloc>();
    final state = bloc.state;

    switch (state) {
      case ProfileLoaded():
        final inActiveColor = blue;
        final stateIsBookmark = state.isBookmark;
        return Container(
          padding: EdgeInsets.only(left: 72.w, right: 72.w, top: 250.h),
          child: Stack(
            children: [
              Center(
                child: Material(
                  elevation: 30,
                  borderRadius: BorderRadius.circular(16),
                  color: inActiveColor,
                  child: Container(
                    alignment: Alignment.center,
                    width: 153.w,
                    height: 68.h,
                  ),
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  ButtonContainer(
                    color: stateIsBookmark ? inActiveColor : null,
                    numberValue: state.profile.articles.length,
                    category: "Posts",
                    onPressed: () =>
                        bloc.add(ToggleUserChoice(isBookmark: false)),
                  ),
                  ButtonContainer(
                    color: stateIsBookmark ? null : inActiveColor,
                    numberValue: state.profile.bookmarks.length,
                    category: "Bookmarks",
                    onPressed: () {
                      bloc.add(ToggleUserChoice(isBookmark: true));
                    },
                  ),
                ],
              ),
            ],
          ),
        );
      default:
        return Center(
          child: Text("Unimplemented state error from RowButton Widget"),
        );
    }
  }
}
