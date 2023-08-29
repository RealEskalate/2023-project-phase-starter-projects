import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../data/models/tag_model.dart';
import '../../domain/entities/tag.dart';
import '../bloc/article_bloc.dart';

class TagList extends StatefulWidget {
  final List<Tag> tagList;

  const TagList({required this.tagList, Key? key}) : super(key: key);

  @override
  State<TagList> createState() => _TagListState();
}

class _TagListState extends State<TagList> {
  int selectedIndex = 0;

  @override
  void initState() {
    // ignore: prefer_const_constructors
    widget.tagList.insert(0, TagModel(name: 'All'));
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 40.0,
      width: MediaQuery.of(context).size.width - 40,
      child: ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: widget.tagList.length,
        itemBuilder: (BuildContext context, int index) {
          return Padding(
            padding: const EdgeInsets.only(right: 8.0),
            child: GestureDetector(
              onTap: () {
                setState(
                  () {
                    selectedIndex = index;
                    if (index == 0) {
                      BlocProvider.of<ArticleBloc>(context).add(
                        LoadAllArticlesEvent(),
                      );
                    } else {
                      BlocProvider.of<ArticleBloc>(context).add(
                        FilterArticlesEvent(
                            Tag(
                              name: widget.tagList[index].name,
                            ),
                            ''),
                      );
                    }
                  },
                );
              },
              child: (selectedIndex == index)
                  ? TagWidget(
                      tagName: widget.tagList[index].name,
                      isSelected: true,
                    )
                  : TagWidget(
                      tagName: widget.tagList[index].name, isSelected: false),
            ),
          );
        },
      ),
    );
  }
}

class TagWidget extends StatelessWidget {
  final String tagName;
  final bool isSelected;

  const TagWidget({required this.tagName, required this.isSelected, Key? key})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      child: Container(
        width: 100,
        decoration: BoxDecoration(
            border: Border.all(color: AppColors.blue, width: 2),
            borderRadius: BorderRadius.circular(1000),
            color: (isSelected) ? AppColors.blue : AppColors.white),
        child: Center(
          child: Text(
            tagName,
            style: TextStyle(
                color: (isSelected) ? AppColors.white : AppColors.blue,
                fontWeight: FontWeight.w200),
          ),
        ),
      ),
    );
  }
}
