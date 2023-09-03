import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:go_router/go_router.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../../../../core/color/colors.dart';
import '../bloc/article_bloc.dart';

class OptionsDialog extends StatelessWidget {
  final String articleId;
  const OptionsDialog({
    super.key,
    required this.articleId,
  });

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<ArticleBloc, ArticleState>(
      builder: (context, state) {
        return PopupMenuButton<String>(
          icon: const Icon(
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
              const PopupMenuItem<String>(
                value: 'Edit article',
                child: Text("Edit article"),
              ),
              const PopupMenuItem<String>(
                value: 'Delete Article',
                child: Text("Delete article"),
              ),
              const PopupMenuItem<String>(
                value: 'Logout',
                child: Text("Logout"),
              ),
            ];
          },
        );
      },
    );
  }

  _handleMenuItemSelected(value, BuildContext context, articleId) async {
    if (value == "Edit article") {
      context.push('/update_article', extra: articleId);
    } else if (value == "Delete Article") {
      final bloc = context.read<ArticleBloc>();
      bloc.add(DeleteArticleEvent(id: articleId));
    } else if (value == "Logout") {
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      prefs.remove('token');
      context.go('/login');
    }
  }
}
