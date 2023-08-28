import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../domain/entities/user_data.dart';
import 'user_bio.dart';
import 'user_profile_info.dart';
import 'user_profile_photo.dart';

class UserProfileDetails extends StatelessWidget {
  final UserData user;
  const UserProfileDetails({Key? key, required this.user}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double horizontalPadding = 40.w;
    double topPadding = 19.h;
    double cardMarginLeft = 32.w;
    double cardMarginTop = 19.h;
    double cardMarginRight = 20.w;
    double cardBorderRadius = 16.0.w;

    return Container(
      padding: EdgeInsets.fromLTRB(
        horizontalPadding,
        topPadding,
        horizontalPadding,
        0,
      ),
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(cardBorderRadius),
        ),
        color: Colors.white,
        child: Container(
          margin: EdgeInsets.fromLTRB(
            cardMarginLeft,
            cardMarginTop,
            cardMarginRight,
            0,
          ),
          child: Column(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  UserProfilePhoto(
                    photoUrl: user.image,
                  ),
                  UserProfileInfo(
                    fullName: user.fullName,
                    username: user.email,
                    profession: user.expertise,
                  ),
                ],
              ),
              UserBio(
                userInfo: user.bio,
              ),
              SizedBox(
                height: 32.w,
              )
            ],
          ),
        ),
      ),
    );
  }
}
