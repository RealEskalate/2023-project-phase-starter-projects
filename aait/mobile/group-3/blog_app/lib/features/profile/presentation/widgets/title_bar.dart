import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';
import 'package:shared_preferences/shared_preferences.dart';

class TitleBar extends StatelessWidget {
  TitleBar({
    super.key,
  });

  final Color blackColor = darkBlue;

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Padding(
          padding: EdgeInsets.only(left: 40.w, top: 68.h),
          child: Text(
            "Profile",
            style: TextStyle(fontSize: 24.sp, fontWeight: FontWeight.w500),
          ),
        ),
        Padding(
          padding: EdgeInsets.only(right: 40.w, top: 68.h),
          child: IconButton(
            onPressed: () {
              print("Hello I am being pressed");
              PopupMenuButton<String>(
                color: Colors.white,
                onSelected: (value) async{
                  final prefs = await SharedPreferences.getInstance();
                  prefs.remove('token');
                  context.go('value');
                },
                itemBuilder: (BuildContext context) {
                  return <PopupMenuEntry<String>>[
                    PopupMenuItem<String>(
                      child: Text("Logout"),
                      value: '/login',
                    ),
                  ];
                },
              );
            },
            icon: Icon(
              Icons.more_horiz,
              color: blackColor,
            ),
          ),
        ),
      ],
    );
  }
}
