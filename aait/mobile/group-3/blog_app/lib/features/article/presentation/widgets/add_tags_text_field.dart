import 'package:flutter/material.dart';

import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/color/colors.dart';

import 'custom_text_field.dart';

class AddTagsTextField extends StatelessWidget {
  const AddTagsTextField({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.end,
      children: [
        const Expanded(
            child: CustomTextField(hint: "Add tags")),
        SizedBox(width: 27.w),
        IconButton(
          onPressed: () {},
          icon: Icon(
            Icons.add_circle_outline,
            size: 36.h,
            color: blue,
          ),
        ),
      ],
    );
  }
}