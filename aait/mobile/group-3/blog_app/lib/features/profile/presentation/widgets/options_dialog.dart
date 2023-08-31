import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:shared_preferences/shared_preferences.dart';

class OptionsDialog extends StatelessWidget {
  const OptionsDialog({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return PopupMenuButton<String>(
      icon: Icon(
        Icons.more_horiz,
        color: darkBlue,
      ),
      onSelected: (value) => _handleMenuItemSelected(value, context),
      itemBuilder: (BuildContext context) {
        return <PopupMenuEntry<String>>[
          PopupMenuItem<String>(
            child: Text("Logout"),
            value: 'Logout',
          ),
        ];
      },
    );
  }

  _handleMenuItemSelected(value, BuildContext context) async {
    if (value == "Logout") {
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      prefs.remove('token');
      context.go('/login');
    }
  }
}
