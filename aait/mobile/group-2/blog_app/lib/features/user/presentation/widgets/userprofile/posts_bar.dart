import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../../core/presentation/theme/app_colors.dart';
import '../../bloc/profile_page_bloc.dart';

class ArticleTitleBar extends StatelessWidget {
  final String title;

  const ArticleTitleBar({
    Key? key,
    required this.title,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    ScreenUtil.init(context);

    double titleFontSize = 20.sp;
    double iconSize = 24.w;
    double iconSpacing = 12.w;

    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text(
          title,
          style: TextStyle(
            fontSize: titleFontSize,
            fontWeight: FontWeight.w500,
            color: AppColors.darkerBlue,
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            GestureDetector(
              onTap: () {
                final currentState = context.read<ProfilePageBloc>().state;
                if (currentState.layout == ProfileLayout.list) {
                  context.read<ProfilePageBloc>().add(SwitchToGridViewEvent());
                }
              },
              child: BlocBuilder<ProfilePageBloc, ProfilePageState>(
                builder: (context, state) {
                  return Icon(
                    Icons.grid_view,
                    color: state.layout == ProfileLayout.grid
                        ? AppColors.blue
                        : AppColors.darkGray,
                    size: iconSize,
                  );
                },
              ),
            ),
            SizedBox(width: iconSpacing),
            GestureDetector(
              onTap: () {
                final currentState = context.read<ProfilePageBloc>().state;
                if (currentState.layout == ProfileLayout.grid) {
                  context.read<ProfilePageBloc>().add(SwitchToListViewEvent());
                }
              },
              child: BlocBuilder<ProfilePageBloc, ProfilePageState>(
                builder: (context, state) {
                  return Icon(
                    Icons.list,
                    color: state.layout == ProfileLayout.list
                        ? AppColors.blue
                        : AppColors.darkGray,
                    size: iconSize,
                  );
                },
              ),
            ),
          ],
        ),
      ],
    );
  }
}
