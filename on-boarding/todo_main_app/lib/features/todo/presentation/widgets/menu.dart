import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher_string.dart';

Widget popUpMenu(BuildContext context) {
  return PopupMenuButton<String>(
    onSelected: (value) async {
      if (value == 'developer') {
        // show dialog "Developed by Gemechis"
        showDialog(
          context: context,
          builder: (BuildContext context) {
            return const AlertDialog(
                title: Text('Developer'),
                content: Text("Developed by @RealGemechis"));
          },
        );
      } else if (value == 'github') {
        const url = 'https://www.github.com/';
        if (await canLaunchUrlString(url)) {
          await launchUrlString(url);
        } else {
          log('Could not launch $url');
        }
      }
    },
    itemBuilder: (BuildContext context) {
      return [
        const PopupMenuItem<String>(
          value: 'developer',
          child: Text('Developer'),
        ),
        const PopupMenuItem<String>(
          value: 'github',
          child: Text('GitHub Link'),
        ),
      ];
    },
  );
}
