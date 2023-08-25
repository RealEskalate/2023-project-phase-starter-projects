import 'package:blog_app/features/user/presentation/widgets/userprofile/user_bio.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/user_profile_info.dart';
import 'package:blog_app/features/user/presentation/widgets/userprofile/user_profile_photo.dart';
import 'package:flutter/material.dart';

class UserProfileDetails extends StatelessWidget {
  const UserProfileDetails({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.fromLTRB(40, 19, 40, 0),
      height: 310,
      child: Card(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(16.0),
        ),
        color: Colors.white,
        child: Container(
          margin: const EdgeInsets.fromLTRB(32, 19, 20, 0),
          child: const Column(
            children: [
              Row(
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
              UserBio(
                userInfo:
                    'Madison Blackstone is a director of user experience design, with experience managing global teams.',
              ),
            ],
          ),
        ),
      ),
    );
  }
}
