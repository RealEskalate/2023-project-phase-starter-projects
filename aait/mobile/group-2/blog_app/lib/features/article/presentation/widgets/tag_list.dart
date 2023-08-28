import 'package:flutter/material.dart';

import '../../../../core/presentation/theme/app_colors.dart';
import '../../domain/entities/tag.dart';

class TagList extends StatelessWidget {
  final List<Tag> tagList;
  const TagList({required this.tagList, super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 40.0,
      width: MediaQuery.of(context).size.width - 40,
      child: ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: tagList.length,
        itemBuilder: (BuildContext context, int index) {
          return Padding(
            padding: const EdgeInsets.only(right: 8.0),
            child: TagWidget(tagName: tagList[index].name),
          );
        },
      ),
    );
  }
}

class TagWidget extends StatelessWidget {
  final String tagName;
  final bool selected = false;
  const TagWidget({required this.tagName, super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 100,
      decoration: BoxDecoration(
          border: Border.all(color: AppColors.blue, width: 2),
          borderRadius: BorderRadius.circular(1000),
          color:
              selected ? Theme.of(context).colorScheme.primary : Colors.white),
      child: Center(
        child: Text(
          tagName,
          style: const TextStyle(
              color: AppColors.blue, fontWeight: FontWeight.w200),
        ),
      ),
    );
  }
}
