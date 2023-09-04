import 'package:blog_app/core/color/colors.dart';
import 'package:blog_app/features/profile/presentation/widgets/options_dialog.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:go_router/go_router.dart';

class TitleBar extends StatelessWidget {
  TitleBar({
    super.key,
  });

  final Color blackColor = darkBlue;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          alignment: Alignment.centerLeft,
          child: BackButton(
            onPressed: () {
              context.pop();
            },
          ),
        ),
        SizedBox(
          height: 10.h,
        ),
        Row(
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
              child: OptionsDialog(),
            ),
          ],
        ),
      ],
    );
  }
}
