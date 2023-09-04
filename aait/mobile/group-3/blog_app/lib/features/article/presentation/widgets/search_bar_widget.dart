import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';


class SearchBarWidget extends StatefulWidget {
  final Function searchByName;
  const SearchBarWidget({super.key, required this.searchByName});

  @override
  _SearchBarWidgetState createState() => _SearchBarWidgetState();
}

class _SearchBarWidgetState extends State<SearchBarWidget> {
  TextEditingController queryController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          width: 379.w,
          height: 70.5.h,
          padding: EdgeInsets.only(left: 15.w),
          decoration: BoxDecoration(
            border: Border.all(color: Colors.grey.withOpacity(0.1)),
            color: Colors.white,
            borderRadius: BorderRadius.circular(10),
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.1),
                spreadRadius: 5,
                blurRadius: 7,
                offset: const Offset(0, 2),
              ),
            ],
          ),
          child: Center(
            child: TextField(
              controller: queryController,
              decoration: InputDecoration(
                hintText: 'Search tasks...',
                hintStyle: TextStyle(
                  color: Theme.of(context).hintColor,
                  fontSize: 15,
                  fontWeight: FontWeight.w300,
                ),
                border: InputBorder.none,
              ),
            ),
          ),
        ),
        Positioned(
          right: 0,
          width: 52.w,
          height: 70.5.h,
          child: ElevatedButton(
            onPressed: () {
              widget.searchByName(queryController.text);
            },
            style: ElevatedButton.styleFrom(
              padding: EdgeInsets.symmetric(vertical: 16.h, horizontal: 16.w),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
            ),
            child: Icon(
              Icons.search, // Clear icon
              color: Colors.white,
              size: 24.h,
            ),
          ),
        ),
      ],
    );
  }

  void _filterArticles(BuildContext context) {
    if (queryController.text.isNotEmpty) {
      //   BlocProvider.of<ArticleBloc>(context).add(FilterArticles(query: queryController.text));
    } else {
      //   BlocProvider.of<ArticleBloc>(context).add(const LoadArticles());
    }
  }
}
