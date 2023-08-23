import 'package:flutter/material.dart';

class Politics extends StatefulWidget {
  const Politics({super.key});

  @override
  State<Politics> createState() => _PoliticsState();
}

class _PoliticsState extends State<Politics> {
  @override
  Widget build(BuildContext context) {
    return Container(child: Center(child: Text('politic'),),);
  }
}