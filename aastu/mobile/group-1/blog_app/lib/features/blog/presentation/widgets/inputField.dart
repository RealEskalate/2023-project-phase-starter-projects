import 'package:flutter/material.dart';

class InputField extends StatelessWidget {
  const InputField({this.label = "", super.key});
  final String label;

  @override
  Widget build(BuildContext build) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(0, 0, 0, 0),
      child: Container(
        // padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
        // margin: EdgeInsets.all(10),zyyyy
        height: 45,
        child: TextField(
          decoration: InputDecoration(
            hintText: label,
            hintStyle: TextStyle(
                color: Colors.grey, fontSize: 20, fontWeight: FontWeight.w400),
          ),
        ),
      ),
    );
  }
}

class MultiLineInputField extends StatelessWidget {
  const MultiLineInputField({this.label = "", super.key});
  final String label;

  @override
  Widget build(BuildContext build) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(0, 40, 0, 20),
      child: Container(
        // padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
        // margin: EdgeInsets.all(10),zyyyy
        child: TextField(
          maxLines: 10,
          keyboardType: TextInputType.multiline,
          decoration: InputDecoration(
            border:
                OutlineInputBorder(borderRadius: BorderRadius.circular(10.0)),
            hintText: label,
            hintStyle: TextStyle(
                color: Colors.grey, fontSize: 20, fontWeight: FontWeight.w400),
          ),
        ),
      ),
    );
  }
}
