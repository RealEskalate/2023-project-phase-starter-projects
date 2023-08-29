import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class UserProfileInfo extends StatelessWidget {
  final String username, fullName, profession;

  const UserProfileInfo({
    Key? key,
    required this.username,
    required this.fullName,
    required this.profession,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double usernameFontSize = 14.sp;
    double fullNameFontSize = 18.sp;
    double professionFontSize = 16.sp;
    double spacing = 2.h;
    double nameSpacing = 11.h;

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          username.length > 7 ? '${username.substring(0, 7)}...' : username,
          style: TextStyle(
            fontSize: usernameFontSize,
            fontWeight: FontWeight.w900,
            color: Color(0xFF2D4379),
            overflow: TextOverflow.ellipsis,
          ),
        ),
        SizedBox(
          height: spacing,
        ),
        Text(
          fullName,
          style: TextStyle(
            fontSize: fullNameFontSize,
            fontWeight: FontWeight.w100,
            fontStyle: FontStyle.italic,
            color: Color(0xFF0D253C),
            overflow: TextOverflow.ellipsis,
          ),
        ),
        SizedBox(
          height: nameSpacing,
        ),
        Text(
          profession,
          style: TextStyle(
            fontSize: professionFontSize,
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.w100,
            color: Color(0xFF376AED),
            overflow: TextOverflow.ellipsis,
          ),
        ),
      ],
    );
  }
}
