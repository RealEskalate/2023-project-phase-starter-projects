import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

ButtonStyle elevatedButtonStyle() {
  return ButtonStyle(
    backgroundColor: MaterialStateProperty.all<Color>(const Color(0xFF376AED)),
    shape: MaterialStateProperty.all<RoundedRectangleBorder>(
        RoundedRectangleBorder(
      borderRadius: BorderRadius.circular(10.r),
    )),
  );
}
