import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_theme.dart';

class CustomAppBar extends StatelessWidget implements PreferredSizeWidget {
  final Widget leading;
  final String title;
  final List<Widget>? actions;

  const CustomAppBar(
      {required this.leading,
      required this.title,
      required this.actions,
      super.key});

  @override
  Widget build(BuildContext context) {
    return AppBar(
      elevation: 0.0,
      title: Center(
        child: Padding(
          padding: EdgeInsets.symmetric(vertical: 20.h),
          child: Text(
            title,
            style: AppTheme.themeData.textTheme.titleMedium,
          ),
        ),
      ),
      leading: leading,
      actions: actions,
      foregroundColor: Colors.black,
      backgroundColor: Theme.of(context).colorScheme.background,
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight);
}
