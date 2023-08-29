import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/tag.dart';
import '../bloc/article_bloc.dart';

class CustomSearchBar extends StatefulWidget {
  const CustomSearchBar({Key? key});

  @override
  _CustomSearchBarState createState() => _CustomSearchBarState();
}

class _CustomSearchBarState extends State<CustomSearchBar> {
  final TextEditingController _textEditingController = TextEditingController();

  @override
  void dispose() {
    _textEditingController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width - 20,
      // height: 60.h,
      decoration: BoxDecoration(
        boxShadow: [
          BoxShadow(
            color: Colors.grey.withOpacity(0.5),
            spreadRadius: 1,
            blurRadius: 3,
            offset: const Offset(0, 1),
          ),
        ],
        borderRadius: BorderRadius.circular(10.0),
        color: Colors.white,
      ),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              controller: _textEditingController,
              style: const TextStyle(
                color: AppColors.darkerBlue,
                fontFamily: 'Poppins',
                fontSize: 18,
              ),
              decoration: InputDecoration(
                hintText: 'Search an article...',
                hintStyle: const TextStyle(
                  color: AppColors.gray300,
                  fontFamily: 'Poppins',
                  fontSize: 18,
                  fontWeight: FontWeight.w200,
                ),
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(10.0),
                  borderSide: const BorderSide(color: Colors.transparent),
                ),
                contentPadding:
                    const EdgeInsets.fromLTRB(15.0, 10.0, 10.0, 0.0).w,
                focusedBorder: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(10.0),
                  borderSide: const BorderSide(color: AppColors.blue),
                ),
                suffixIcon: GestureDetector(
                  onTap: () {
                    final value = _textEditingController.text;
                    BlocProvider.of<ArticleBloc>(context)
                        .add(FilterArticlesEvent(Tag(name: ''), value));
                  },
                  child: const SearchIcon(),
                ),
              ),
              onSubmitted: (value) {
                BlocProvider.of<ArticleBloc>(context)
                    .add(FilterArticlesEvent(Tag(name: ''), value));
              },
            ),
          ),
        ],
      ),
    );
  }
}

class SearchIcon extends StatelessWidget {
  const SearchIcon({Key? key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 60.h,
      width: 52.w,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(10.0),
        color: AppColors.lightBlue,
      ),
      child: const Icon(
        Icons.search,
        size: 30,
        color: AppColors.white,
      ),
    );
  }
}
