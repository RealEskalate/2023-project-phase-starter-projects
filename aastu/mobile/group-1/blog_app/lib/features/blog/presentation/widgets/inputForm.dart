import 'package:blog_app/features/blog/presentation/widgets/AddButtonCustom.dart';
import 'package:blog_app/features/blog/presentation/widgets/inputField.dart';
import 'package:flutter/material.dart';

class InputForm extends StatelessWidget {
  const InputForm({super.key});

  @override
  Widget build(BuildContext build) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      // mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        InputField(label: "Add title"),
        InputField(label: "Add subtitle"),
        Row(
          mainAxisSize: MainAxisSize.max,
          children: [
            Expanded(child: InputField(label: "Add tags")),
            AddButtonCustom()
          ],
        ),
        Text(
          "Add as many tags as you want",
          style: TextStyle(fontSize: 16),
        ),
        Container(
          padding: EdgeInsets.fromLTRB(0, 15, 0, 0),
          child: Wrap(
            spacing: 5,
            // add vertical spacing here
            runSpacing: 5,
            children: [
              generateChip("Art"),
              generateChip("Design"),
              generateChip("Technology"),
              generateChip("Art"),
              generateChip("Design"),
              generateChip("Technology"),
            ],
          ),
        ),
        MultiLineInputField(label: "Article content"),
      ],
    );
  }

  Container generateChip(String labelText) {
    return Container(
      padding: EdgeInsets.fromLTRB(10, 0, 0, 0),
      child: Chip(
        deleteIconColor: Colors.blue,
        label: Text(
          labelText,
          style: TextStyle(color: Colors.blue, fontSize: 14),
        ),
        backgroundColor: Colors.white,
        shape: StadiumBorder(
          side: BorderSide(color: Colors.blue, width: 1),
        ),
        onDeleted: () {
          // Handle delete action
        },
      ),
    );
  }
}
