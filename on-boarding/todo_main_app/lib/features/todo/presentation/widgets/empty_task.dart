import 'package:flutter/material.dart';

Widget emptyTask() {
  return Column(
    children: <Widget>[
      const SizedBox(height: 10),
      Container(
        margin: const EdgeInsets.only(left: 20, right: 20),
        child: const Text(
          'You have no tasks yet. Create a new task by tapping on the add button below.',
          style: TextStyle(
            fontSize: 16,
            color: Colors.grey,
          ),
        ),
      ),
      const SizedBox(height: 100),
    ],
  );
}
