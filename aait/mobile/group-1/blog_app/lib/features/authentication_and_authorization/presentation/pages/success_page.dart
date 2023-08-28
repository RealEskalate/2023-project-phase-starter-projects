import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

class Success_Page extends StatefulWidget {
  const Success_Page({super.key});

  @override
  State<Success_Page> createState() => _Success_PageState();
}

class _Success_PageState extends State<Success_Page> {
  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: double.infinity,
      color: Colors.green,
    );
  }
}