import 'package:flutter/material.dart';

Widget taskNotFound() {
  return Container(
    margin: const EdgeInsets.only(left: 20, right: 20),
    child: TextField(
      decoration: InputDecoration(
        filled: true,
        fillColor: const Color(0xffF1EEEE),
        border: OutlineInputBorder(
          borderSide: BorderSide.none,
          borderRadius: BorderRadius.circular(8),
        ),
        focusedBorder: OutlineInputBorder(
          borderSide: const BorderSide(
              color: Color.fromARGB(255, 255, 248, 250), width: 1),
          borderRadius: BorderRadius.circular(8),
        ),
        hintText: "Task not found",
      ),
      style: const TextStyle(
        fontSize: 17,
      ),
    ),
  );
}
