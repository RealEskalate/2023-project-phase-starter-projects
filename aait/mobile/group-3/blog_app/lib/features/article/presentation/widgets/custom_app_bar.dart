import 'package:blog_app/core/color/colors.dart';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:go_router/go_router.dart';

class OptionsDialog extends StatelessWidget {
  final String articleId;
  const OptionsDialog({
    super.key,
    required this.articleId,
  });

  @override
  Widget build(BuildContext context) {
    return PopupMenuButton<String>(
      icon: Icon(
        Icons.more_horiz,
        color: darkBlue,
      ),
      onSelected: (value) => _handleMenuItemSelected(
        value,
        context,
        this.articleId,
      ),
      itemBuilder: (BuildContext context) {
        return <PopupMenuEntry<String>>[
          PopupMenuItem<String>(
            child: Text("Edit article"),
            value: 'Edit article',
          ),
          PopupMenuItem<String>(
            child: Text("Delete article"),
            value: 'Delete Article',
          ),
          PopupMenuItem<String>(
            child: Text("Logout"),
            value: 'Logout',
          ),
        ];
      },
    );
  }

  _handleMenuItemSelected(value, BuildContext context, articleId) async {
    if (value == "Edit article") {
      context.push('/update_article', extra: articleId);
    } else if (value == "Delete Article") {
      print("I am being pressed here");
    } else if (value == "Logout") {
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      prefs.remove('token');
      context.go('/login');
    }
  }
}
