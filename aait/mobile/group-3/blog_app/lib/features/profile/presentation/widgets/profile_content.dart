import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../domain/entity/profile.dart';
import 'about_section.dart';
import 'basic_information_widget.dart';
import 'profile_image.dart';

class ProfileContent extends StatelessWidget {
  final Profile profile;
  final VoidCallback onChangeImage;

  const ProfileContent({super.key, required this.profile, required this.onChangeImage});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 40.w),
      child: Card(
        shape:
            RoundedRectangleBorder(borderRadius: BorderRadius.circular(20.r)),
        elevation: 3,
        child: Column(
          children: [
            Row(
              children: [
                Container(
                  alignment: Alignment.centerLeft,
                  padding:
                      EdgeInsets.symmetric(horizontal: 32.w, vertical: 32.h),
                  child: ProfileImage(
                    imageName: profile.imageName,
                    onChangeImage: onChangeImage,
                  ),
                ),
                SizedBox(
                  width: 20.w,
                ),
                Container(
                  child: BasicInformationWidget(
                      username: profile.username,
                      fullName: profile.fullName,
                      occupation: profile.expertise),
                ),
                SizedBox(
                  height: 24.h,
                ),
              ],
            ),
            Container(
              padding: EdgeInsets.symmetric(horizontal: 32.w),
              alignment: Alignment.centerLeft,
              child: AboutSection(description: profile.bio),
            ),
          ],
        ),
      ),
    );
  }
}
