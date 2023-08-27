import 'package:blog_app/features/user/presentation/widgets/userprofile/user_bio.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/user_profile_info.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/user_profile_photo.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class UserProfileDetails extends StatelessWidget {
  const UserProfileDetails({
    Key? key,
  }) : super(key: key);

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
              const Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  UserProfilePhoto(
                    photoUrl:
                        'https://img.freepik.com/premium-photo/young-handsome-man-with-beard-isolated-keeping-arms-crossed-frontal-position_1368-132662.jpg',
                  ),
                  UserProfileInfo(
                    fullName: 'Jovi Daniel',
                    username: '@joviedan',
                    profession: 'UX Designer',
                  ),
                ],
              ),
              const UserBio(
                userInfo:
                    'Madison Blackstone is a director of user experience design, with experience managing global teams.',
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
