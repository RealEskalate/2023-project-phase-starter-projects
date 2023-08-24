import 'package:flutter/material.dart';


class AppDimension {
  static double myDeviceWidth = 390;
  static double myDeviceHeight = 844;
  static width(double requiredWidth, BuildContext context) {
    return MediaQuery.of(context).size.width / (myDeviceWidth / requiredWidth);
  }

  static height(double requiredHeight, BuildContext context) {
    return MediaQuery.of(context).size.height /
        (myDeviceHeight / requiredHeight);
  }
}
